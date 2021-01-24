    //class code
    Logger log = LogManager.GetCurrentClassLogger()
    var result = AsyncContext.RunTask(MyAsyncMethod("", true, log).Result;
    
    //log method
    public async Task SomeMethod(string name, bool isWindowsOs, ILogger log)
    {
                this.Name = name;
                this.isWindows = isWindowsOs;
                this.logger = log;   
                string configPath = 
                Utility.GetFilePathAsPerOs(this.ConfigurationFilePath, 
                           isWindows);
    
                if (!System.IO.File.Exists(ConfigPath))
                {
                    Console.WriteLine($"{ConfigPath} was not found");
                    logger.Error($"[{this.Name}] : Configuration file not found");
                    await Task.CompletedTask;
                }  
                // Rest of the Code
    }
