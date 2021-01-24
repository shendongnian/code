    protected async override Task HandleSignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
    {
        // ...
        if (!signInContext.Properties.ExpiresUtc.HasValue)
        {
            signInContext.Properties.ExpiresUtc = issuedUtc.Add(Options.ExpireTimeSpan);
        }
    
        await Events.SigningIn(signInContext);
    
        if (signInContext.Properties.IsPersistent)
        {
            var expiresUtc = signInContext.Properties.ExpiresUtc ?? issuedUtc.Add(Options.ExpireTimeSpan);
            signInContext.CookieOptions.Expires = expiresUtc.ToUniversalTime();
        }
    
        var ticket = new AuthenticationTicket(signInContext.Principal, signInContext.Properties, signInContext.Scheme.Name);
        // ...
    
    }
