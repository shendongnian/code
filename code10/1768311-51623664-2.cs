    services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        // disable the built-in validation
        options.User.RequireUniqueEmail = false;
    })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
