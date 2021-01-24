       // Identity Context
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration["DefaultConnection"],
                                    sqlOptions => sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().
                                    Assembly.GetName().Name));
            },
                ServiceLifetime.Scoped
            );
            // Configure default Identity implementation
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
