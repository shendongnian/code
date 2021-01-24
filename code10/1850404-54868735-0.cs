    services.AddIdentity<IdentityUser, IdentityRole>(config =>
    {
            config.Password.RequireNonAlphanumeric = false; //optional
            config.SignIn.RequireConfirmedEmail = true; //optional
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
