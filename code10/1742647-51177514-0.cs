    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddOpenIdConnect(options =>
        {
            options.Authority = Configuration["AuthoritySite"];
            options.ClientId = Configuration["ClientId"];
            options.ClientSecret = Configuration["ClientSecret"];
            options.Scope.Clear();
            // options.Scope.Add("Any:Scope");
            options.ResponseType = OpenIdConnectResponseType.CodeIdTokenToken;
            options.SaveTokens = true;
    
            options.GetClaimsFromUserInfoEndpoint = true;
    
            options.TokenValidationParameters = new TokenValidationParameters
            {
                // Compensate server drift
                ClockSkew = TimeSpan.FromHours(12),
                // Ensure key
                IssuerSigningKey = CERTIFICATE,
    
                // Ensure expiry
                RequireExpirationTime = true,
                ValidateLifetime = true,                    
    
                // Save token
                SaveSigninToken = true
            };                
    
        });
    
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Mvc", policy =>
            {
                policy.AuthenticationSchemes.Add(OpenIdConnectDefaults.AuthenticationScheme);
                policy.RequireAuthenticatedUser();
            });
        });
    }
