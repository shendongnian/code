     public IServiceProvider ConfigureServices(IServiceCollection services) {
        //Service injection and setup
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
                    services.AddScoped<IUrlHelper>(factory =>
                    {
                        var actionContext = factory.GetService<IActionContextAccessor>()
                                                   .ActionContext;
                        return new UrlHelper(actionContext);
                    });
    
        //....
    
       // Build the intermediate service provider then return it
        return services.BuildServiceProvider();
    }
