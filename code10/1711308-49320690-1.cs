    services.AddAuthentication(IdentityServerConstants.DefaultCookieAuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        // base-address of your identityserver
                        options.Authority = Configuration.GetSection("Settings").GetValue<string>("Authority");
                        // name of the API resource
                        options.ApiName = "testapi";
                        options.RequireHttpsMetadata = false;
                    }); 
