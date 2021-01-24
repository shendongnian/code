    public void ConfigureServices(IServiceCollection services)
    {
        // [...]
        // OLD: services.AddScoped<IRepository<ApplicationUser>, UserRepository>();
        services.AddScoped<UserRepository>();
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        // [...]
    }
