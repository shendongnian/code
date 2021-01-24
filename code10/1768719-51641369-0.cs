    ICollection<IWebElement> links = driver.FindElements(By.TagName("a"));
    
    foreach(int i=0; i<links.Count(); i++)
    {
        ICollection<IWebElement> newLinks = driver.FindElements(By.TagName("a"));
        newLinks[i].Click();
        driver.Navigate().Back();
    }
