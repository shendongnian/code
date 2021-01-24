    public static void WaitForElementToBecomeVisibleWithinTimeout(IWebDriver driver, 
        IWebElement element, int timeout)
    {
	    new WebDriverWait(driver,                 
            TimeSpan.FromSeconds(timeout)).Until(ElementIsVisible(element));
    }
    private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
    {
	    return driver =>
	    {
		    try
		    {
			    return element.Displayed;
		    }
		    catch (Exception)
		    {
			    // If element is null, stale or if it cannot be located
			    return false;
		    }
	    };
    }
