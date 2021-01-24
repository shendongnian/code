    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Interactions;
    using System.Threading;
    
    namespace Exercise1
    {
        class RunPath
        {
                static void Main()
                {
                    IWebDriver webDriver = new ChromeDriver();
                    webDriver.Navigate().GoToUrl("https://energy.gocompare.com/gas-electricity");
                    webDriver.Manage().Window.Maximize();
    
                    webDriver.FindElement(By.XPath(".//button[@type = 'submit']")).Click();
    				
    				WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                    IWebElement error = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'validation-error')]")));
                    Assert.AreEqual("Please provide your postcode, as different regions have different fuel prices.", validationError.TextTrim());
    			}
        }			
    }	
