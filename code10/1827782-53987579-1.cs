    var clients = new List<Client>
    {
        new Client
        {
            ClientId = "MyClientApp",                    
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,                    
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AllowedScopes =
            {
                "myApi",
                "Role",
                IdentityServerConstants.StandardScopes.OpenId
            }
        }
    };
    var response = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
    {
        Address = _discoveryResponse.TokenEndpoint,
        ClientId = "MyClientApp",
        ClientSecret = "secret",
        Scope = "openid Role myApi",
        UserName = username,
        Password = password
    });
