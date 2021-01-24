    public static void Configure(Assembly assembly)
    {
        ILoggerRepository repository = LogManager.GetRepository(assembly);
        XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        
        // ...
    }
