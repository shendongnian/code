    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
    var element = wait.Until(condition =>
    {
        try
        {
            var elementToBeDisplayed = driver.FindElement(By.Id("content-section"));
            return elementToBeDisplayed.Displayed;
        }
        catch (StaleElementReferenceException)
        {
            return false;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    });
