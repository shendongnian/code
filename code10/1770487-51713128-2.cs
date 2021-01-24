     var dropdown = Driver.FindElement(By.XPath("//*[@id='language-dd']"));
    var coll = Driver.FindElements(By.XPath("//*[@id='language-dd']/ul/li"));
    foreach (var item in coll)
    {
    	dropdown.Click();
    	item.WaitForElementToBeClickable(30);
    	item.Click();
    }
    
    public static void WaitForElementToBeClickable(this IWebElement element, int timeout)
    {
    	new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementToBeClickable(element));
    }
