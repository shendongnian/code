            public static void WaitForNotVisible(IWebElement element, IWebDriver driver)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(drv =>
                {
                    try
                    {
                        if (element.Displayed)
                        {
                            return false;
                        }
                        return true;
                    }
                    catch
                    {
                        return true;
                    }
                });
            }
