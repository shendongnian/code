    services.AddAuthentication(OAuth2IntrospectionDefaults.AuthenticationScheme)
        .AddOAuth2Introspection(options =>
        {
            options.IntrospectionEndpoint = "#REDACTED#";
            options.ClientId = "#REDACTED#";
            options.ClientSecret = "#REDACTED#";
            // We are using introspection for JWTs so we need to override the default
            options.SkipTokensWithDots = false;
        });
