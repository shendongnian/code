            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("WebApplicationTestingDatabase"));//.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<ApplicationUser>(options =>
                {
                    // Identity options configuration
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                })
                .AddUserStore<UserStore<ApplicationUser, IdentityRole<long>, ApplicationDbContext, long>>()
                .AddDefaultTokenProviders()
                .AddSignInManager<SignInManager<ApplicationUser>>();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                }).AddCookie(IdentityConstants.ApplicationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account/Login");
                    o.Events = new CookieAuthenticationEvents()
                    {
                        OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
                    };
                }).AddCookie(IdentityConstants.ExternalScheme, o =>
                {
                    o.Cookie.Name = IdentityConstants.ExternalScheme;
                    o.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                })
                .AddCookie(IdentityConstants.TwoFactorRememberMeScheme,
                    o => o.Cookie.Name = IdentityConstants.TwoFactorRememberMeScheme)
                .AddCookie(IdentityConstants.TwoFactorUserIdScheme,
                    o =>
                    {
                        o.Cookie.Name = IdentityConstants.TwoFactorUserIdScheme;
                        o.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                    }
                );
            services.AddScoped<ISecurityStampValidator, SecurityStampValidator<ApplicationUser>>();
