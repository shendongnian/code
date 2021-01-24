    services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "Cookies";
                })
               .AddCookie("Cookies", options =>
               {
                   options.LoginPath = new PathString("/Development/Account/Login");
                   options.AccessDeniedPath = new PathString("/Development/Account/Login");
                   options.LogoutPath = new PathString("/Development/Account/Logout");
                   options.ExpireTimeSpan = TimeSpan.FromDays(1);
               });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    var configAuthority = container.GetInstance<IOptions<CoPilotConfig>>().Value?.IdentityAuthority;
                    options.Authority = configAuthority ?? $"http://localhost:{Constants.LOOPBACK_PORT}";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "CoPilotApi";
                });
