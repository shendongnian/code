    public bool IsElementVisible(IWebElement element)
    {
        return element.Displayed && element.Enabled;
    }
    
    IF(IsElementVisible(banner) == false)
    { execute set of steps to set the banner }
