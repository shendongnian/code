    Notifications = new OpenIdConnectAuthenticationNotifications()
    {
        SecurityTokenValidated = context => SecurityTokenValidatedInternal(context),
        RedirectToIdentityProvider = context =>
        {
            var code = context.OwinContext.Authentication.AuthenticationResponseChallenge.Properties.Dictionary["AccessCode"];
            context.ProtocolMessage.SetParameter("Code", code);
            return Task.FromResult(0);
        }
    }
