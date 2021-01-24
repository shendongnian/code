    services.AddIdentity<AppUser, IdentityRole>()
                    .AddDefaultUI()
                    .AddRoles<IdentityRole>()
                    .AddRoleManager<RoleManager<IdentityRole>>()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<authContext>();
