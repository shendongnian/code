      services.AddIdentity<ApplicationUser,IdentityRole>(options=>
            {
                options.User.RequireUniqueEmail = true;               
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;      
              
            })
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAuthorization();
            services.AddAuthentication();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); 
