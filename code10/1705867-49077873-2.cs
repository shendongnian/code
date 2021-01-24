    public class KeyVaultCache
    {
        private KeyVaultClient _KeyVaultClient = null;
        public KeyVaultClient KeyVaultClient
        {
            get
            {
                if(_KeyVaultClient is null)
                {
                    var provider = new AzureServiceTokenProvider();
                    _KeyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
                }
                return _KeyVaultClient;
            }
        }
        private ConcurrentDictionary<string, string> SecretsCache = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public async Task<string> GetCachedSecret(string secretName)
        {
            if(!SecretsCache.ContainsKey(secretName))
            {
                var secretBundle = await KeyVaultClient.GetSecretAsync($"{AzureUris.KeyVaultSecrets}{secretName}").ConfigureAwait(false);
                SecretsCache.TryAdd(secretName, secretBundle.Value);
            }
            return SecretsCache.ContainsKey(secretName) ? SecretsCache[secretName] : string.Empty;
        }
    }
