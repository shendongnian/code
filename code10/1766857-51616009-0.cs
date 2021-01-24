    // In OpenIddict RC2, all the options used to be grouped.
    services.AddOpenIddict(options =>
    {
        options.AddEntityFrameworkCoreStores<ApplicationDbContext>();
    
        options.AddMvcBinders();
    
        options.EnableAuthorizationEndpoint("/connect/authorize")
               .EnableLogoutEndpoint("/connect/logout")
               .EnableTokenEndpoint("/connect/token")
               .EnableUserinfoEndpoint("/api/userinfo");
    
        options.AllowAuthorizationCodeFlow()
               .AllowPasswordFlow()
               .AllowRefreshTokenFlow();
    
        options.RegisterScopes(OpenIdConnectConstants.Scopes.Email,
                               OpenIdConnectConstants.Scopes.Profile,
                               OpenIddictConstants.Scopes.Roles);
    
        options.RequireClientIdentification();
    
        options.EnableRequestCaching();
    
        options.EnableScopeValidation();
    
        options.DisableHttpsRequirement();
    });
    // In OpenIddict RC3, the options are now split into 3 categories:
    // the core services, the server services and the validation services.
    services.AddOpenIddict()
        .AddCore(options =>
        {
            // AddEntityFrameworkCoreStores() is now UseEntityFrameworkCore().
            options.UseEntityFrameworkCore()
                   .UseDbContext<ApplicationDbContext>();
        })
    
        .AddServer(options =>
        {
            // AddMvcBinders() is now UseMvc().
            options.UseMvc();
    
            options.EnableAuthorizationEndpoint("/connect/authorize")
                   .EnableLogoutEndpoint("/connect/logout")
                   .EnableTokenEndpoint("/connect/token")
                   .EnableUserinfoEndpoint("/api/userinfo");
    
            options.AllowAuthorizationCodeFlow()
                   .AllowPasswordFlow()
                   .AllowRefreshTokenFlow();
    
            options.RegisterScopes(OpenIdConnectConstants.Scopes.Email,
                                   OpenIdConnectConstants.Scopes.Profile,
                                   OpenIddictConstants.Scopes.Roles);
    
            // This API was removed as client identification is now
            // required by default. You can remove or comment this line.
            //
            // options.RequireClientIdentification();
    
            options.EnableRequestCaching();
    
            // This API was removed as scope validation is now enforced
            // by default. You can safely remove or comment this line.
            //
            // options.EnableScopeValidation();
    
            options.DisableHttpsRequirement();
        });
