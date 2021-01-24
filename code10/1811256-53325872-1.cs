            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(
                    options =>
                    {
                        options.Authority = "http://localhost:5000";
                        options.ApiName = "api1";
                        options.ApiSecret = "scopeSecret";
                        options.RequireHttpsMetadata = false;
                        // You will almost certainly want these at some point too,
                        // to prevent the API talking to the IS for every
                        // API call.  Adjust the duration as desired.
                        options.EnableCaching = true;
                        options.CacheDuration = TimeSpan.FromMinutes(10);
                    });
