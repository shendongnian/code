     public void ConfigureServices(IServiceCollection services)
     {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IInitializationService, InitializationService>();
            
            services.AddMvc();
     }
     public void Configure(IApplicationBuilder app, IHostingEnvironment env)
     {
            // more code ...
            
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var identityDbInitialize = scope.ServiceProvider.GetService<IInitializationService>();
                identityDbInitialize.Seed();
            }
          // more code ...
     }
