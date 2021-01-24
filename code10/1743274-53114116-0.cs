    //remove this: services.AddDefaultIdentity<IdentityUser>()
    //use this instead to get the Identity basics without any default UI:
    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    
    //this assumes you want to continue using razor views for your identity UI
    //it specifies areas can be used with razor pages and then adds an 
    //authorize filter with a default policy for the folder /Account/Manage and
    //the page /Account/Logout.cshtml (both of which live in Areas/Identity/Pages)
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        .AddRazorPagesOptions(options =>
        {
            options.AllowAreas = true;
            options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
            options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
        });
    //configures the application cookie to redirect on challenge, etc.
    services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = $"/Identity/Account/Login";
        options.LogoutPath = $"/Identity/Account/Logout";
        options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    });
    //configures an email sender for e.g. password resets
    services.AddSingleton<IEmailSender, EmailSender>();
