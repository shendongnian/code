        // Third party code - Selenium.
    public abstract class DriverOptions { }
    public class ChromeOptions : DriverOptions { }
    public class FirefoxOptions : DriverOptions { }
    // My code
    public interface IWebDriverFactory<in T>
    {
        IWebDriver GetWebDriver(T options);
    }
    public class ChromeWebDriverFactory : IWebDriverFactory<ChromeOptions>
    {
        public IWebDriver GetWebDriver(ChromeOptions options)
        {
            // implementation details for initalising Chrome and use options from ChromeOptions
        }
    }
    public class FirefoxWebDriverFactory : IWebDriverFactory<FirefoxOptions>
    {
        public IWebDriver GetWebDriver(FirefoxOptions options)
        {
            // implementation details for initalising Firefox and use options from FirefoxOptions
        }
    }
