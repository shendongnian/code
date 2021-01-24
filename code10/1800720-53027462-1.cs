    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    namespace ListVMsConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string tenantId = "xxxxxx";
                string clientId = "xxxxxx";
                string redirectUri = "https://ListClassicVMsApp";
    
                string apiNew = "https://management.azure.com/subscriptions/xxxxxxxx/providers/Microsoft.Compute/virtualMachines?api-version=2018-06-01";
                string apiOld = "https://management.core.windows.net/xxxxxxxx/services/vmimages";
    
                AzureRestClient client = new AzureRestClient(tenantId, clientId, redirectUri);
    
                //OK - I can list the managed VMs.         
                //string resultNew = client.GetRequestAsync(apiNew).Result;
    
                // 403 forbidden - should work now
                string resultOld = client.GetRequestAsync(apiOld).Result;
            }
    
        }
    
        public class AzureRestClient
        {
            private readonly HttpClient _client;
    
            public AzureRestClient(string tenantName, string clientId, string redirectUri)
            {
                _client = CreateClient(tenantName, clientId, redirectUri).Result;
            }
    
            private async Task<string> GetAccessToken(string tenantName, string clientId, string redirectUri)
            {
                string authString = "https://login.microsoftonline.com/" + tenantName;
                string resourceUrl = "https://management.core.windows.net/";
    
                var authenticationContext = new AuthenticationContext(authString, false);
                var authenticationResult = await authenticationContext.AcquireTokenAsync(resourceUrl, clientId, new Uri(redirectUri), new PlatformParameters(PromptBehavior.Auto));
    
                return authenticationResult.AccessToken;
            }
    
            async Task<HttpClient> CreateClient(string tenantName, string clientId, string redirectUri)
            {
                string token = await GetAccessToken(tenantName, clientId, redirectUri);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Add("x-ms-version", "2014-02-01");
                return client;
            }
    
            public async Task<string> GetRequestAsync(string url)
            {
                return await _client.GetStringAsync(url);
            }
        }
    }
