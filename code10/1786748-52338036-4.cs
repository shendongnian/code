    public static bool WaitUntilOneFormLoaded(IWebDriver driver)
    {
        var task1 = IsFormLoaded(driver, "//some/xpath1");
        var task2 = IsFormLoaded(driver, "//some/xpath2");
        Task.WaitAny(task1, task2);
        var completedTask = Task.WaitAny(task1, task2);
        switch (completedTask)
        {
            case 0: return task1.Result;
            case 1: return task2.Result;
            default: return false; // Timeout
        }
    }
    
    public static Task<bool> IsFormLoaded(IWebDriver driver, string xpath)
    {
        return Task.Run(() =>
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(x => driver.FindElement(By.XPath(xpath)).GetAttribute("value").Length > 1);
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        });
    }
