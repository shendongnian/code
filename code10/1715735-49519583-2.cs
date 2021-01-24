    using SampleProj.Pages;
    using SampleProj.Utilities;
    using NUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using System;
    namespace SampleProj.Tests
    {
        class LoginTests : DriverUtil
        {
            [SetUp]
            public void Setup()
            {
                string URL = "your website url";
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(URL);
                Console.WriteLine("Opened Browser & Navigated to URL");
            }
            [TearDown]
            public void TearDown()
            {
                driver.Close();
                driver.Quit();
                Console.WriteLine("Browser Closed.");
            }
            [Test]  /// Successful Login
            public void Successful_Login()
            {
                Login pgLogin = new Login();
                Home pgHome = pgLogin.SubmitValidCredentials("user email", "user password");
                pgHome.ConfirmHomePage();
                Console.WriteLine("Test Complete");
            }
        }
    }
