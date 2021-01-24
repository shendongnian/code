    using SampleProj.Utilities;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using System;
    namespace SampleProj.Pages
    {
        class Login : DriverUtil
        {
            public Login() 
            { 
              PageFactory.InitElements(DriverUtil.driver, this); 
            }
            // Email
            [FindsBy(How = How.Name, Using = "email")]
            public IWebElement Email { get; set; }
            // Password
            [FindsBy(How = How.Name, Using = "password")]
            public IWebElement Password { get; set; }
            // Login Button
            [FindsBy(How = How.Name, Using = "submitter")]
            public IWebElement LoginButton { get; set; }
            // Enter and Submit Login Credentials
            public Dashboard SubmitLogin(string email, string password)
            {
                Email.SendKeys(email);
                Password.SendKeys(password);
                LoginButton.Click();
                // BaseUtil.cs contains shared functionality
                BaseUtil.WaitForPage();
                Console.WriteLine("Login Credentials Submitted");
                return new Dashboard();
            }
          }
  }
