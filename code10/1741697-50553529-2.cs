    public static IWebDriver _driver;
    public IWebDriver Driver { 
        get {
            if(_driver == null)
            {  
                var options = new ChromeOptions();
                options.AddArgument("disable-infobars");
                var _driver = new ChromeDriver(options);
            }
            return _driver;
        }
    }
    public void Watcher_Changed(object sender, FileSystemEventArgs e)
    {
        Driver.Navigate().GoToUrl("file:///" + filename);
        Driver.Navigate().Refresh();
    }
