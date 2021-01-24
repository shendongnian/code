    public static class ExtensionMethods
    {
        
        public static bool RetryingClick(this IWebElement element)
        {
            Stopwatch crono = Stopwatch.StartNew();
            while (crono.Elapsed < TimeSpan.FromSeconds(60))
            {
                try
                {
                    element.Click();
                    return true;
                }
                catch (ElementNotVisibleException)
                {
                    Logger.LogMessage("El elemento no es visible. Reintentando...");
                }
                catch (StaleElementReferenceException)
                {
                    Logger.LogMessage("El elemento ha desaparecido del DOM. Finalizando ejecución");
                }
                Thread.Sleep(250);
            }
            throw new WebDriverTimeoutException("El elemento no ha sido clicado en el tiempo límite. Finalizando ejecución");
        }
    }
