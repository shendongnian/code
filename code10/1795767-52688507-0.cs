     class Program
        {
            private  static ILogger logger;
            private bool isWindows;
    
            static async Task Main(string[] args)
            {
              ILoggerFactory loggerFactory = new LoggerFactory().AddConsole();
                
                
                
                logger = loggerFactory.CreateLogger<Program>();
    
                logger.LogError("ooops");
                await new Program().SomeMethod("name", true, logger);
               
               Console.ReadLine();
    
    
    
            }
            public async Task SomeMethod(string name, bool isWindowsOs, ILogger log)
            {
                this.Name = name;
                this.isWindows = isWindowsOs;
                logger = log;
                //string configPath =
                //    Utility.GetFilePathAsPerOs(this.ConfigurationFilePath,
                //        isWindows);
    
                //if (!System.IO.File.Exists(ConfigPath))
                //{
                //    Console.WriteLine($"{ConfigPath} was not found");
                //    logger.Error($"[{this.Name}] : Configuration file not found");
                //    await Task.CompletedTask;
                //}
                 logger.LogInformation("this is just confirmation for a successfull task");
                logger.LogError("ooops");
                
                // Rest of the Code
            }
    
            public string Name { get; set; }
        }
