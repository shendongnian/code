    services.AddAuthentication(IdentityServerConstants.DefaultCookieAuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = authority;
                    options.ApiName = "testapi";
                    options.RequireHttpsMetadata = false;
                });
