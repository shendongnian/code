    public static void WaitForElementByName(TimeSpan timeout, string elementName)
    {
        WindowsDriver<WindowsElement> driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), desktopCapabilities, timeout);
        driver.Manage().Timeouts().ImplicitlyWait(timeout);
        WebDriverWait wait = new WebDriverWait(driver, timeout);
        wait.Until(ExpectedConditions.ElementIsVisible(OpenQA.Selenium.By.Name(elementName)));
    }
