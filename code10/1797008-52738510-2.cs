    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    
    namespace MyTest.UITest
    {
        class Program
    {
        static void Main(string[] args)
        {
           
            //Create the reference
            IWebDriver driver =new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            IWebElement ele = driver.FindElement(By.Id("gs_htif0"));
            ele.SendKeys("Execute Automation");
        }
    }
