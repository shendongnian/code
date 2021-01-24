    public void ConfigureServices(IServiceCollection services)
    {
        ...
        //Change the following pre-fab lines from
        //services.AddDefaultIdentity<ApplicationUser>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>();
        //To
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                //You might not need the following two settings
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
        ...
    }
