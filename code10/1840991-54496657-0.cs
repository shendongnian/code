    services.AddDbContext<IdentityContext>(); //make sure it's same database as IdentityServer4
    services.AddIdentityCore<ApplicationUser>(options => { });
    new IdentityBuilder(typeof(ApplicationUser), typeof(IdentityRole), services)
        .AddRoleManager<RoleManager<IdentityRole>>()
        .AddSignInManager<SignInManager<ApplicationUser>>()
        .AddEntityFrameworkStores<IdentityContext>();
