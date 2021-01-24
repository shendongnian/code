    public void ConfigureServices(IServiceCollection services)
    {
        // register MVC services
        services.AddMvc();
        // register configuration
        services.Configure<AppConfiguration>(Configuration.GetSection("RestCalls")); 
        // register custom services
        services.AddScoped<IUserService, UserService>();
        ...
    }
