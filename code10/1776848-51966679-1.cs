    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AtLeast21", policy =>
                policy.Requirements.Add(new MinimumAgeRequirement(21)));
        });
    }
