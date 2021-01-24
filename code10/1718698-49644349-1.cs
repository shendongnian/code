    public static void WaitAndClick(this IWebDriver driver, IWebElement webelement)
    {
        var fluentWait = new WebDriverWait(driver, Configuration.WaitTime);
        fluentWait.Until(webDriver =>
        {
            try
            {
                webelement.Click();
            }
            catch (Exception ex)
            {
                if (ex is TargetInvocationException ||
                    ex is NoSuchElementException ||
                    ex is InvalidOperationException ||
                    ex is ElementNotVisibleException)
                {
                    return false; //The function will rerun.
                }
                {
                    throw; //Throw exception if it's not a type to be ignored.
                }
            }
            return true;
        });
    }
