    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            // ... rest of configuration
            services.AddMvc( options=>
            {
                // ... rest of configuration
                options.ModelBinderProviders.Insert(0, new DecimalBinderProvider());
            }
        );
    }
