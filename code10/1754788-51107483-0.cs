    services.AddAuthentication(sharedOpts =>
            {
                sharedOpts.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOpts.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddAzureAd(opts => Configuration.Bind("AzureAd", opts))
            .AddCookie(opts => {
                opts.Cookie.Domain = ""; <-- This made the difference
            });
