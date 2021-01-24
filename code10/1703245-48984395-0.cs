    public static void LoginGmail (IWebDriver driver, string email, string password )
        {          
            var loginBox = driver.FindElement(By.Id("Email"));
            loginBox.SendKeys(email);
            var nextBtn = driver.FindElement(By.Id("next"));
            nextBtn.Click();
            var pwBox = driver.FindElement(By.Id("Passwd"));
            pwBox.SendKeys(password);
            var signinBtn = driver.FindElement(By.Id("signIn"));
            signinBtn.Click();
        }
