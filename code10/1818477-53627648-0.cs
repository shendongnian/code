    services.AddAuthorization(options =>
    {
        options.AddPolicy("BadgeEntry", policy =>
            policy.RequireAssertion(context =>
                context.User.HasClaim(c =>
                    (c.Type == ClaimTypes.BadgeId ||
                     c.Type == ClaimTypes.TemporaryBadgeId) &&
                     c.Issuer == "https://microsoftsecurity")));
    });
