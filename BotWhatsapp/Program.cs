using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

namespace BotWhatsapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://web.whatsapp.com";

            //Aqui definimos em qual grupo ou contato o bot irá interagir
            List<string> contatos = new List<string>()
            {
                "TI técnicos"
            };


            ChromeDriver driver = new ChromeDriver();
     
            //Abrimos o navegador Crome na pagina definida no inicio
            driver.Navigate().GoToUrl(url);

            //Maximizamos a tela
            driver.Manage().Window.Maximize();


            //Ele vai criar uma instacia do navegador e tem que te o tempo scanear o QrCode
            Thread.Sleep(20000);


            //O serviço irá percorrer toda lista de contatos 
            foreach (var contato in contatos)
            {
                //Pesquisa ELemento
                //var pesquisaElemento = driver.FindElementByClassName.("_251VP");

                var pesquisaElemento = driver.FindElement(By.ClassName("_13NKt"));
                pesquisaElemento.SendKeys(contato);

                //Tempo para o pesquisar o contato
                Thread.Sleep(1000);

                //Interação com o Contato
                var contatoElemento = driver.FindElement(By.XPath($"//span[@title='{contato}']"));
                contatoElemento.Click();

                //Busca o elemento campo mensagem
                var chatElemento = driver.FindElement(By.ClassName("fd365im1"));

                //Tempo para processar mensagem
                Thread.Sleep(1000);

                //Mensagem que vamos enviar para o Contato
                chatElemento.SendKeys("Olá eu sou o Bot do Keller!");

                //Tempo para processar mensagem
                Thread.Sleep(5000);

                //Busca o botao de enviar mensagems
                var botaoEnviarMensagem = driver.FindElement(By.XPath($"//span[@data-icon='send']"));       
                botaoEnviarMensagem.Click();


                //Tempo para processar mensagem
                Thread.Sleep(5000);


                //Mensagem que vamos enviar para o Contato
                chatElemento.SendKeys("Em que posso ajudar?");

                //Busca o botao de enviar mensagems
                botaoEnviarMensagem = driver.FindElement(By.XPath($"//span[@data-icon='send']"));
                botaoEnviarMensagem.Click();

                //Tempo para finalizar o processo
                Thread.Sleep(5000);
            }
        }
    }
}
