    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace UpdateKeyVaultSecret
    {
        class Program
        {
            static void Main(string[] args)
            {
                UpdateSecretAttributes("https://rohitvault1.vault.azure.net/secrets/mysecret1").GetAwaiter().GetResult();
    
                Console.ReadLine();
            }
    
            
            private static async Task<string> GetAccessTokenAsync(string authority, string resource, string scope)
            {
                var authContext = new AuthenticationContext(authority);
                ClientCredential clientCred = new ClientCredential("<my-app-clientid>", "<my-app-client-secret>");
                AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);
    
                if (result == null)
                    throw new InvalidOperationException("Failed to obtain the JWT token");
    
                return result.AccessToken;
            }
    
            public static async Task<string> GetSecretFromVault(string secretKeyIdentifier)
            {
                var client = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(GetAccessTokenAsync),
                    new System.Net.Http.HttpClient());
    
                var secret = await client.GetSecretAsync(secretKeyIdentifier).ConfigureAwait(false);
    
                return secret.Value;
            }
    
            public static async Task<string> UpdateSecretAttributes(string secretKeyIdentifier)
            {
                var client = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(GetAccessTokenAsync),
                    new System.Net.Http.HttpClient());
    
                SecretAttributes attributes = new SecretAttributes();
    	    attributes.Expires = DateTime.UtcNow.AddDays(15);
    
                var secret = await client.UpdateSecretAsync(secretKeyIdentifier, null, attributes, null).ConfigureAwait(false);
    
                return secret.Value;
            }
        }
    }
