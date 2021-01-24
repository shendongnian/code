    public IWebDriver Instance { get; set; }
    
    
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    
    
    namespace Nunit_ParalelizeTest
    {
        public class Base
        {
            protected IWebDriver _driver;
    
    
            [TearDown]
            public void TearDown()
            {
                _driver.Close();
                _driver.Quit();
            }
    
    
            [SetUp]
            public void Setup()
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
            }
        }
    }
