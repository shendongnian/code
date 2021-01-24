    services
        .AddAuthentication(...)
        .AddOpenIdConnect(options =>
        {
            ...
    
            options.Events = new OpenIdConnectEvents
            {
                OnRedirectToIdentityProvider = ctx =>
                {
                    if (ctx.HttpContext.Request.Query.TryGetValue("user", out var stringValues))
                        ctx.ProtocolMessage.LoginHint = stringValues[0];
    
                    return Task.CompletedTask;
                }
            };
        });
