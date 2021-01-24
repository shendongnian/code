    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    namespace AutomatedTests
    {
        [TestFixture]
        public class LoginTests
        {
            public static string BaseUrl = "http://www.example.com";
            public static string LoggedInPageTitle = "Dashboard Page";
    
            Dictionary<string, string> username_password = new Dictionary<string, string>()
                {
                    {"JonhJohnson", "pwD123"},
                    {"DanielSmith", "pass!@#"},
                    {"RichardSummers", "secret_word"}
                };
    
    
            [TestCase]
            public void CanLoginWithAllUsers()
            {
                var driver = new FirefoxDriver();
    
                driver.Navigate().GoToUrl(BaseUrl);
    
                foreach (KeyValuePair<string, string> pair in username_password)
                {
                    TestContext.WriteLine("Attempting ti sign in with user: {0}, who's password is: {1}", pair.Key, pair.Value);
    
                    var usernameField = driver.FindElement(By.Id("Username"));
                    usernameField.SendKeys(pair.Key);
    
                    var passwordField = driver.FindElement(By.Id("Password"));
                    passwordField.SendKeys(pair.Value);
    
                    var loginButton = driver.FindElement(By.Id("Log in"));
                    loginButton.Click();
    
                    Assert.That(driver.Title == LoggedInPageTitle, "Failed to login with user {0}", pair.Key);
    
                    var signOutButton = driver.FindElement(By.Id("Sign out"));
                    signOutButton.Click();
                }
    
                driver.Quit();
    
            }
    
        }
    }
