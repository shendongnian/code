    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        // Adds a default in-memory implementation of IDistributedCache.
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            // Set a short timeout for easy testing.
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
        });
    }
