    services.AddDefaultIdentity<IdentityUser>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
    services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        .AddRazorPagesOptions(options =>
        {
            options.Conventions.AddPageRoute("/Dashboards/Dashboard1", "");
            options.Conventions.AllowAnonymousToPage("/Login");
        });
    services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
        opt => {
            //configure your other properties
            opt.LoginPath = "/Login";
        });
