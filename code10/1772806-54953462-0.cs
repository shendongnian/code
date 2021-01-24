    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore()
             .AddDataAnnotations()
             /* etc. */;
    }
