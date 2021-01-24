            try
            {
                return wait.Until(driver => driver.FindElement(locator));
            }
            catch (NoSuchElementException)
            {
            }
            catch (ElementNotVisibleException)
            {
            }
            catch (WebDriverTimeoutException)
            {
            }
            return null;
        }`
