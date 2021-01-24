    public TokenValidationParameters GetTokenValidationParameter(string domain, string audience)
    {
        IConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{domain}.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
        var openIdConfig = AsyncHelper.RunSync(async () => await configurationManager.GetConfigurationAsync(CancellationToken.None));
    
        return new TokenValidationParameters
        {
            ValidIssuer = $"{domain}",
            ValidAudiences = new[] { audience },
            IssuerSigningKeys = openIdConfig.SigningKeys
        };
    }
