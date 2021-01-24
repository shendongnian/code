    // Job setup
    static void Main()
    {
        var services = new ServiceCollection();
        // Register your services here
        services.AddSingleton<ClassB>();
        services.AddScoped<ClassC>();
        var serviceProvider = services.BuildServiceProvider();
        var config = new JobHostConfiguration
        {
            JobActivator = new JobServiceProviderActivator(serviceProvider)
        };
    
        var host = new JobHost(config);
        host.RunAndBlock();
    }
