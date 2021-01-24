    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    
        var logFactory = LogManager.LoadConfiguration("nLog.config");
        
        foreach (var setting in config.GetChildren().ToDictionary(x => x.Key, x => x.Value))
        {
            logFactory.Configuration.Variables[setting.Key] = setting.Value;
        }
    
        var target = logFactory.Configuration.FindTargetByName("elastic") as ElasticSearchTarget;
        target.Uri = config.GetConnectionString("ElasticUrl");
    
        NLogBuilder.ConfigureNLog("nLog.config");
        var logger = LogManager.GetCurrentClassLogger();  
        var host = WebHost.CreateDefaultBuilder(args)                   
                          .UseContentRoot(Directory.GetCurrentDirectory())
                          .UseNLog()  
                          .Build();
    
            host.Run();     
    
    }
