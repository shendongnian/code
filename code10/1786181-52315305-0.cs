    services.AddAuthentication()
        .AddOpenIdConnect("test", "test", options =>
        {
            options.Authority = "xxx";
            options.ClientId = "xxx";
            options.Scope.Add(IdentityServerConstants.StandardScopes.OpenId);
            options.Scope.Add(IdentityServerConstants.StandardScopes.Profile);
            options.Scope.Add(IdentityServerConstants.StandardScopes.Email);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = ClaimsIdentity.DefaultNameClaimType,
                RoleClaimType = ClaimsIdentity.DefaultRoleClaimType
            };
            options.Events.OnRedirectToIdentityProvider = ctx =>
            {
                if (ctx.Properties.Items.TryGetValue("userId", out var userId))
                {
                    ctx.ProtocolMessage.LoginHint = userId;
                }
                return Task.CompletedTask;
            };
        });
