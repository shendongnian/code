    services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = config.Authentication.Authority;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = ServerApiName;
                    options.ApiSecret = ServerApiAppClientSecret;
                });
