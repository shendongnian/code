    private void CreateServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddSingleton(_hostingEnvironment);
        services.AddSingleton(_hostBuilderContext);
        services.AddSingleton(_appConfiguration);
        services.AddSingleton<IApplicationLifetime, ApplicationLifetime>();
        services.AddSingleton<IHostLifetime, ConsoleLifetime>();
        services.AddSingleton<IHost, Host>();
        services.AddOptions();
        services.AddLogging();//<--HERE
        
        //...
