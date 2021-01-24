    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    
    namespace Exercise1
    {
        class Program
        {
            static void Main(string[] args)
            {
                IWebDriver webDriver = new ChromeDriver(@"Path to my chrome driver defined here");
                webDriver.Navigate().GoToUrl("www.asos.com");
                driver.FindElement(By.XPath("//*[@id="chrome - header"]/header/div[2]/div/ul/li[3]/div/button')]")).Click();
    
                var country = driver.FindElement(By.Id("country"));
                var select_country = new SelectElement(country);
                select_country = SelectByValue("IN");
    
                var currency = driver.FindElement(By.Id("currency"));
                var select_currency = new SelectElement(currency);
                select_currency = SelectByValue("2");
    
                driver.FindElement(By.XPath("//*[@id="chrome - header"]/header/div[5]/div[2]/div/section/form/div[3]/button")).Click();
    
            }
    }
