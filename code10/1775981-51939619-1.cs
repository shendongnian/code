    services.Configure<CookiePolicyOptions>(options =>
    {
        // No consent check needed here
        options.CheckConsentNeeded = context => false;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });
