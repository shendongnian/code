    private void ClickLoginButton()
    {
        try
        {
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(1));    
            LoginButton.Click();
        }
        catch (WebDriverTimeoutException) { }
        finally
        {
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(originalTime));
        }
    }
 
