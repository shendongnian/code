    public static class RemoteWebDriverExtensions
    {
        public static void Goto(this RemoteWebDriver driver, string url)
        {
             driver.Navigate().GoToUrl(url);
             driver.ExecuteScript("console.log('Using selenium');");
        }
    }
