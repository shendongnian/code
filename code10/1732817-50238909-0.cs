    public string GetValue(string labelName)
    {
        IWebElement e = Driver.FindElement(By.XPath($"//span[contains(.,'{labelName}')]"));
        string s = (string)((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].nextSibling.textContent;", e);
        return s.Trim();
    }
