    public static void FindElement(this IWebDriver driver, By by, int timeout)
    {
       if(timeout >0)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementToBeClickable(by));
        }
    
     return driver.FindElement(by);
    }
    
     public static IReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeout)
    {
       if(timeout >0)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }
    
     return driver.FindElements(by);
    }
