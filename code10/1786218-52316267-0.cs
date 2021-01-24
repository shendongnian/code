     [TestMethod]
            public void OpenPatEarningCode()
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    Actions action = new Actions(driver);
    
                    var Menu = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Menu")));
    
                    action.MoveToElement(Menu).Build().Perform();
    
                    IWebElement FirstmenuAdmin = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("First Menu")));
    
                    action.MoveToElement(FirstmenuAdmin).Build().Perform();
    
    
                    IWebElement SubmenuElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("Sub Menu")));
    
                    SubmenuElement.Click();
                }
                catch (Exception)
                {
    
                    throw;
                }
            }
