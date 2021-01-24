    /// <summary>
    /// Called by the KeyVaultClient instance.
    /// </summary>
    /// <param name="authority"></param>
    /// <param name="resource"></param>
    /// <param name="scope"></param>
    /// <returns></returns>
    private static async Task<string> GetAccessTokenAsync(string authority, string resource, string scope)
    {
        var clientCredential = new ClientCredential(Constants.Vault.AppId, Constants.Vault.AppSecret);
        
        var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
        
        AuthenticationResult result = await context.AcquireTokenAsync(resource, clientCredential);
        
        return result.AccessToken;
    }
