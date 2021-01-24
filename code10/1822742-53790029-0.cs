    public bool ElementExists(By locator)
    {
        try
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(locator));
            return true;
        }
        catch (Exception e) when (e is NoSuchElementException || e is WebDriverTimeoutException)
        {
            return false;
        }
    }
