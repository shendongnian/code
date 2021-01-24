        var domain = $"https://{config.Properties["Auth0Domain"]}/";
        var apiIdentifier = config.Properties["Auth0ApiIdentifier"] as string;
        //var keyResolver = new OpenIdConnectSigningKeyResolver(domain);
        //app.UseJwtBearerAuthentication(
        //    new JwtBearerAuthenticationOptions
        //    {
        //        AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
        //        TokenValidationParameters = new TokenValidationParameters()
        //        {
        //            ValidAudience = apiIdentifier,
        //            ValidIssuer = domain,
        //            IssuerSigningKeyResolver = (token, securityToken, identifier, parameters) => keyResolver.GetSigningKey(identifier)
        //        }
        //    });
        var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    domain.TrimEnd('/') + "/.well-known/openid-configuration",
                    new OpenIdConnectConfigurationRetriever());
        app.UseJwtBearerAuthentication(
            new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = apiIdentifier,
                    ValidIssuer = domain,
                    IssuerSigningKeyResolver = (token, securityToken, identifier, parameters) =>
                    {
                        var openIdConnectConfig = Task.Run(() => configurationManager.GetConfigurationAsync()).GetAwaiter().GetResult();
                        return openIdConnectConfig.SigningKeys;
                    }
                }
            });
