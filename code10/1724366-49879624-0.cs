    public static void Main() {
        IServiceCollection serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var application = new MyApplication(serviceCollection);
        // Run
        // ...
    }
    static private void ConfigureServices(IServiceCollection services) {
        ILoggerFactory loggerFactory = new Logging.LoggerFactory();
        services.AddInstance<ILoggerFactory>(loggerFactory);
        //...
    }
