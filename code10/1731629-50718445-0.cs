    public void ConfigureServices(IServiceCollection services)
    {
        #region Database configuration
    
        // Database configuration
        services.AddDbContext<DbContext>(options =>
            options.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));
    
        #endregion Database configuration
    }
