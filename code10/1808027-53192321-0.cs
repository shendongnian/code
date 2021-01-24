    using System;
    using System.Timers;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    
    namespace ConsoleApplication2
    {
        internal class Program
        {
            IWebDriver driver = null;
            
            public static void Main(string[] args)
            {
                
            }
    
            [SetUp]
            public void Initialize()
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.google.pt/");
                Console.WriteLine("INITIALIZE complete");
            }
            
            [Test]
            public void TestGoogleSearch()
            {
                IWebElement element = driver.FindElement(By.Name("q"));
                
                element.SendKeys("ivo cunha");
                Console.WriteLine("IVO complete");
            }
            
            [Test]
            public void TestGoogleSearch2()
            {
                IWebElement element = driver.FindElement(By.Name("q"));
                
                element.SendKeys("adam o'brien");
                Console.WriteLine("ADAM complete");
            }
            
            [TearDown]
            public void CleanUp()
            {
                System.Threading.Thread.Sleep(2500);
                driver.Close();
                driver.Quit();
                driver.Dispose();
                Console.WriteLine("CLEANUP complete");
            }
        }
    }
