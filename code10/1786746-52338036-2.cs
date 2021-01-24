    public static bool WaitUntilOneFormLoaded(IWebDriver driver)
    {
        var task1 = IsFormLoaded(driver, "//some/xpath1"); // Form 1
        var task2 = IsFormLoaded(driver, "//some/xpath2"); // Form 2
        Task.WaitAny(task1, task2);
        return task1.Result || task2.Result;
    }
    
    public static async Task<bool> IsFormLoaded(IWebDriver driver, string xpath)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(x => driver.FindElement(By.XPath(xpath)).GetAttribute("value").Length > 1);
            return await Task.FromResult(true);
        }
        catch (TimeoutException)
        {
            return await Task.FromResult(false);
        }
    }
