    services.AddCors(options =>
    {
        options.AddPolicy(DEFAULT_POLICY_NAME, policy =>
        {
            policy.SetIsOriginAllowedToAllowWildcardSubdomains() 
                 .AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowCredentials();
        });
    });
