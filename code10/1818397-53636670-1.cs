    services.AddMvc().AddRazorPagesOptions(opts =>
    {
        opts.Conventions.AddPageRoute("/DataManagement", "/");
        opts.Conventions.AddPageRoute("/DataManagement", "home");
        opts.Conventions.AddPageRoute("/DataManagement", "index");
    }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
