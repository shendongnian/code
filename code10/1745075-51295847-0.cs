    // USE METHOD WITH LESS DEFAULTS
    //
    // services.AddDefaultIdentity<IdentityUser>()
    //    .AddEntityFrameworkStores<ApplicationDbContext>();
    services.AddIdentity<IdentityUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    //
    // ADD A ROUTE BELOW THE DEFAULT ROUTE
    //
    routes.MapRoute(
                name: "identity",
                template: "Identity/{controller=Account}/{action=Register}/{id?}");
