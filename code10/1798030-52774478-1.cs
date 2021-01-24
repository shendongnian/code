        private void ConfigureTokenServices(IServiceCollection services)
        {
            // Add Token Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters =
                             new TokenValidationParameters
                             {
                                 ValidateIssuer = true,
                                 ValidateAudience = true,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,
                                 ValidIssuer = "Custom.Security.Bearer",
                                 ValidAudience = "Custom.Security.Bearer",
                                 IssuerSigningKey = JwtSecurityKey.Create("Yout securitykey which must be a very long string to work")
                             };
                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Debug.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Debug.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Guest",
                    policy => policy.RequireClaim("Role", "Add here your roles"));
            });
        }
