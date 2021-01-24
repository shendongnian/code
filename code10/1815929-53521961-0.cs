        public void ConfigureServices(IServiceCollection services)
        {
            // ... omitted
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(
                    IdentityServerAuthenticationDefaults.AuthenticationScheme,
                    jwtOptions =>
                    {
                        jwtOptions.Authority = "http://localhost:5000";
                        jwtOptions.RequireHttpsMetadata = false;
                        // This previously was: options.ApiName = scopeName;
                        jwtOptions.Audience = scopeName;
                        // Option 1: if you want to turn off issuer validation
                        //jwtOptions.TokenValidationParameters.ValidateIssuer = false;
                        // Option 2: if you want to support multiple issuers
                        jwtOptions.TokenValidationParameters.ValidIssuers = new[]
                        {
                            "http://localhost:5000",
                            "http://127.0.0.1:5000",
                        };
                    },
                    null
                );
				
            // ... omitted
        }
