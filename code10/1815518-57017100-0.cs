    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.KeyVault;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Newtonsoft.Json;
    
    namespace TradingReplay.Engine
    {
        public class SecurityCredentials : Serialisable<SecurityCredentials, SecurityCredentials>
        {
            public string VaultUrl { get; set; }
            public string ApplicationId {get; set;}
            private string ApplicationSecret { get; set; }
            internal Dictionary<string, string> Cache { get; set; } = new Dictionary<string, string>();
    
            public SecurityCredentials()
            { }
    
            public SecurityCredentials(string vaultUrl, string applicationId, string applicationSecret)
            {
                VaultUrl = vaultUrl;
                ApplicationId = applicationId;
                ApplicationSecret = applicationSecret;
            }
    
            public async Task<SecurityCredentials> InitialiseAzure()
            {
                var client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAccessTokenAsync), new HttpClient());
                var secrets = await client.GetSecretsAsync(VaultUrl);
    
                foreach (var item in secrets)
                    Cache.Add(item.Identifier.Name, await GetSecretAsync(client, item.Identifier.Name));
    
                return this;
            }
    
            public async Task<string> GetSecretAsync(string key)
            {
                if (Cache.TryGetValue(key, out var value))
                    return value;
                else
                {
                    var client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAccessTokenAsync), new HttpClient());
                    var secret = await GetSecretAsync(client, key);
                    Cache.Add(key, secret);
                    return secret;
                }
            }
    
            public async Task<string> GetSecretAsync(KeyVaultClient client, string key)
            {
                var secret = await client.GetSecretAsync(VaultUrl, key);
                return secret.Value;
            }
    
            private async Task<string> GetAccessTokenAsync(string authority, string resource, string scope)
            {
                var appCredentials = new ClientCredential(ApplicationId, ApplicationSecret);
                var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
    
                var result = await context.AcquireTokenAsync(resource, appCredentials);
    
                return result.AccessToken;
            }
        }
    }
