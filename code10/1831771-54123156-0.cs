    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IFirstService, FirstService>();
    
        var serviceProvider = services.BuildServiceProvider();
        var firstService = serviceProvider.GetService<IFirstService>();
    	// now pass firstService to AddMyServices method or get that directly in it
    }
