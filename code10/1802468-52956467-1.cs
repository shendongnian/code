    void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
            .AddControllersAsServices();
    
        services.AddTransient(sp => new V1.SomeController(new Provider(new V1Storage())));
        services.AddTransient(sp => new V2.SomeController(new Provider(new V2Storage())));
    }
