    // Note, you must use the specific class here, rather than the
    // base class, as the base class does not have the proper method
    // overload. Also, the UseSpecCompliantProtocol property is required.
    ChromeOptions options = new ChromeOptions
    {
        PlatformName = "Windows 10",
        BrowserVersion = "latest",
        UseSpecCompliantProtocol = true
    };
    Dictionary<string, object> sauceOptions = new Dictionary<string, object>
    {
        { "username", SauceUsername },
        { "accessKey", SauceAccessKey },
        { "name", TestContext.TestName },
        { "seleniumVersion", "3.11.0" }
    };
    options.AddAdditionalCapability("sauce:options", sauceOptions, true);
    _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"),
        options.ToCapabilities(), TimeSpan.FromSeconds(600));
