    public void ConfigureServices(IServiceCollection services)
    {
        // ... 
        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders();
        // ...
        services.Configure<IdentityOptions>(options =>
        {
            // Configure your password, lockout, user settings here via `options`
        });
        // ...
        services.AddScoped<IUserClaimsPrincipalFactory<User>, UserClaimsFactory>();
        // ...
        services.AddMvc(options =>{ /* ... */ });
    }
