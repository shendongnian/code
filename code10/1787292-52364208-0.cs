    public void ConfigureServices(IServiceCollection services)
    {
        // ... 
        // Configure security policies 
        services.AddAuthorization(options =>
        {
            options.AddPolicy("SuperAdmins", policy => policy.RequireRole("SuperAdmin"));
            options.AddPolicy("Admins", policy => policy.RequireRole("Admin", "SuperAdmin"));
            options.AddPolicy("Customers", policy => policy.RequireRole("Customer", "Admin", "SuperAdmin"));
        });
        // ... 
        services.AddScoped<IUserClaimsPrincipalFactory<User>, MyUserClaimsFactory>();
        // ... 
    }
