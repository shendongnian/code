    public void NavigateToEnvironment(IWebDriver driver, string environment)
            {
                var tile = driver.FindElement(By.XPath($"//span[text()='{environment}']"),5);
    
                Actions action = new Actions(driver);
                action.MoveToElement(tile).Perform();
    
                var tile2 = driver
                        .FindElement(By.XPath("//*[@id='content']/div/div/div/div/ul"))
                        .FindElements(By.TagName("li"))
                        .Where(x => !string.IsNullOrWhiteSpace(x.Text))
                        .ToList();
    
                var singleTile = tile2.Single(x => x.Text.Contains(environment));
                driver.FindElement(By.XPath($"//*[@id='content']/div/div/div/div/ul/li[{tile2.IndexOf(singleTile) + 1}]/div[1]/div[2]/div/button[1]")).Click();
            }
