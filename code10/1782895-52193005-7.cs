    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(...)
            .AddViewComponentsAsServices();
        // ...
    }
