    Create appsettings.json in your project with content :
    `
    {
      "Environments": {
        "QA": {
          "Url": "somevalue",
     "Username": "someuser",
          "Password": "somepwd"
      },
      "BrowserConfig": {
        "Browser": "Chrome",
        "Headless": "true"
      },
      "EnvironmentSelected": {
        "Environment": "QA" 
      }
    }
    `
    
    `
     public static class Configuration
        {
            private static IConfiguration _configuration;
    
            static Configuration()
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json");
    
                _configuration = builder.Build();
    
            }
            public static Browser GetBrowser()
            {
    
                if (_configuration.GetSection("BrowserConfig:Browser").Value == "Firefox")
                {
                    return Browser.Firefox;
                }
                if (_configuration.GetSection("BrowserConfig:Browser").Value == "Edge")
                {
                    return Browser.Edge;
                }
                if (_configuration.GetSection("BrowserConfig:Browser").Value == "IE")
                {
                    return Browser.InternetExplorer;
                }
                return Browser.Chrome;
            }
    
            public static bool IsHeadless()
            {
                return _configuration.GetSection("BrowserConfig:Headless").Value == "true";
            }
    
            public static string GetEnvironment()
            {
                return _configuration.GetSection("EnvironmentSelected")["Environment"];
            }
            public static IConfigurationSection EnvironmentInfo()
            {
                var env = GetEnvironment();
                return _configuration.GetSection($@"Environments:{env}");
            }
    
        }
    `
    
    `
     public void Login()
            {
                var environment = Configuration.EnvironmentInfo();
                Email.SendKeys(environment["username"]);
                Password.SendKeys(environment["password"]);
                WaitForElementToBeClickableAndClick(_driver, SignIn);
            }
    `
