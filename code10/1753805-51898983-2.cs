    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
    services.AddAuthentication(IISDefaults.AuthenticationScheme);
    services.AddIdentity<MyUser, IdentityRole>()
         .AddUserStore<MyUserStore>()
         .AddRoleStore<MyRoleStore>()
         .AddDefaultTokenProviders();
    services.Remove(services.FirstOrDefault(x => x.ServiceType == typeof(IAuthenticationService)));
    services.Add(new ServiceDescriptor(typeof(IAuthenticationService),typeof(AuthenticationHandler), ServiceLifetime.Scoped));
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
