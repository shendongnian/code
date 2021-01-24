    public void ConfigureServices(IServiceCollection services) {
     
        services.AddScoped<IUserManager, UserManager>(); // Add my custom manager
    
        //...
    }
