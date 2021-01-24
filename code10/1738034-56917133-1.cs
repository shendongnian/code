            services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, 
                UserClaimsPrincipalFactory<IdentityUser, IdentityRole>>();
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<TranslatorDbContext>();
