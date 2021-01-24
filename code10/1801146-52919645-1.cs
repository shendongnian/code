    public class SecretManager
    {
        KeyVaultClient client;
        public SecretManager(KeyVaultClient client){ this.client = client; }
        public Task<string> GetSecretAsync(string secretName){
            //here I wrap the logic mentioned above
        }
    }
