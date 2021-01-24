    [Test]
    public void SimpleSelenium4Example()
    {
        //TODO please supply your Sauce Labs user name in an environment variable
        var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
        //TODO please supply your own Sauce Labs access Key in an environment variable
        var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
        var options = new EdgeOptions()
        {
            BrowserVersion = "latest",
            PlatformName = "Windows 10"
        };
        var sauceOptions = new Dictionary<string, object>();
        sauceOptions["username"] = sauceUserName;
        sauceOptions["accessKey"] = sauceAccessKey;
        sauceOptions["name"] = TestContext.CurrentContext.Test.Name;
        
        options.AddAdditionalCapability("sauce:options", sauceOptions);
        Driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(),
            TimeSpan.FromSeconds(600));
        Driver.Navigate().GoToUrl("https://www.google.com");
        Assert.Pass();
    }
