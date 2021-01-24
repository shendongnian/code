    public void ConfigureServices(IServiceCollection services)
    {
        // [...]
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        // [...]
    }
