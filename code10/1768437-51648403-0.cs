    var builder = services.AddIdentityCore<ContosoUniversityUser>(opt =>
            {
                // Configure Password Options
                opt.Password.RequireDigit = true;
            }
            );
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddRoleValidator<RoleValidator<IdentityRole>>();
            builder.AddRoleManager<RoleManager<IdentityRole>>();
            builder.AddSignInManager<SignInManager<ContosoUniversityUser>>();
            builder.AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
