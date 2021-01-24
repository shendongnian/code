    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IKernel>(new StandardKernel());
        services.AddSingleton<IControllerActivator, ControllerActivator>();
        
        services.AddSingleton<IDatabaseContextFactory, DatabaseContextFactory>();
        services.AddSingleton<IDatabaseGateway, DatabaseGateway>();
        services.AddSingleton<IDatabaseContextCache, ContextDatabaseContextCache>();
        // and so on
    }
