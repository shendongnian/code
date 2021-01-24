    protected static WindowsDriver<WindowsElement> desktopSession;
    
    public static void waitForElementName(long timeout, string elementName)
    {
        WebDriverWait wait = new WebDriverWait(desktopSession,TimeSpan.FromSeconds(timeout));
        wait.Until(ExpectedConditions.ElementIsVisible(OpenQA.Selenium.By.Name(elementName)));     
    } 
