            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddUserStore<CustomUserStore>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                ;
            services.AddScoped<DbContext, ApplicationDbContext>();
