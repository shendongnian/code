            services.AddIdentity<IdentityUser, IdentityRole>(o => {
                o.Password.RequiredLength = 8;
            })
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationDbContext>();
