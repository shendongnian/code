    public bool ClickAndWaitUntilInvisible(By targetLocator)
    {
        try
        {
            Waits.Default.Until(ExpectedConditions.ElementToBeClickable(targetLocator)).Click();
            return Waits.Default.Until(ExpectedConditions.InvisibilityOfElementLocated(targetLocator));
        }
        catch (TimeoutException)
        {
            return false;
        }
    }
