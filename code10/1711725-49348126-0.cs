    .AddOpenIdConnect("oidc", options =>
    {
        options.SignInScheme = "Cookies";
        options.Authority = appconfig["OidcAuthority"];
        options.ClientId = appconfig["OidcClientId"];
        options.ClientSecret = appconfig["OidcClientSecret"];
        // other config omitted
        options.Events = new OpenIdConnectEvents
        {
            OnRedirectToIdentityProvider = context =>
            {
                context.Properties.Items.Add("invitationkey", "somevalue");
                return Task.FromResult<object>(null);
            },
            OnTicketReceived = context =>
            {
                var invitation = context.Properties.Items["invitationkey"];
                return Task.FromResult<object>(null);
            }
        }
    };
