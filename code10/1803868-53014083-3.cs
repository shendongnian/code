    public async Task<bool> DoesSecretExist(string accessToken, string keyVaultBaseUrl, string secretName)
    {
        var kvClient = new KeyVaultClient(accessToken);
        try
        {
            IPage<SecretItem> secretVersions = await kvClient.GetSecretVersionsAsync(keyVaultBaseUrl, secretName)
                                                 .ConfigureAwait(false);
            if (!secretVersions.Any())
                return false;
            return true;
        }
        catch (Exception )
        {
            throw;
        }
    }
