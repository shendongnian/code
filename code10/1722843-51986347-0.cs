    options.Events = new OpenIdConnectEvents()
    {
        options.Events.OnRedirectToIdentityProviderForSignOut = context =>
        {
            context.ProtocolMessage.IssuerAddress =
                GetAbsoluteUri(Configuration["oidc:EndSessionEndpoint"], Configuration["oidc:Authority"]);
            return Task.CompletedTask;
        };
	}
