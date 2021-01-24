     services.Configure(AzureADDefaults.CookieScheme, options =>
        {
        options.Cookie.SameSite = SameSiteMode.None;
        });
    
    services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                 .AddAzureAD(options => Configuration.Bind("AzureAd", options));
