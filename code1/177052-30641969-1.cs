    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using NUnit.Framework;
    using System.IO;
    using System.Collections;
    using System.Drawing.Imaging;
    
    namespace FacebookRegistrationUsingC_Sharp
    {
        [TestFixture]
        public class ScreenShot
        {
            IWebDriver driver = null;
            IWebElement element = null;
    
            [SetUp]
            public void SetUp()
            {
                driver = new ChromeDriver("G:\\Selenium_Csharp\\Jar\\chromedriver_win32");           
                driver.Navigate().GoToUrl("https://www.Facebook.com");
                driver.Manage().Window.Maximize();
    
            }
            [Test]
            public void TestScreenShot()
            {           
                    
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("e:\\pande", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
    
            [TearDown]
            public void TearDown()
            {
                driver = null;
                element = null;
            }
        }
    }
