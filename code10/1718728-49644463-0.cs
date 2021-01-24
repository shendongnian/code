    services.AddAuthentication(IdentityServerConstants.DefaultCookieAuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        // base-address of your identityserver
                        options.Authority = settingsSetup.Settings.Authority;
                        // name of the API resource
                        options.ApiName = "testapi";
                        options.RequireHttpsMetadata = false;
                    });
