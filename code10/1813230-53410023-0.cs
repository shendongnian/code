        public IWebElement Get(By byLocator, double seconds = 10)
        {
            IWebElement element = null;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            try
            {
                element = wait.Until(ExpectedConditions.ElementExists(byLocator));
            }
            catch (Exception) { }
            return element;
        }
