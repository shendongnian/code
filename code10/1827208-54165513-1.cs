    using Microsoft.Identity.Client;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    namespace TestAzureFunctionLogin
    {
    public class ManualTestApp
    {
        static string ClientId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"; //replace with AppID from Client App Azure AD registration
        static string ServiceId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"; //replace with AppID from Service App Azure AD registration
        static string Scope = $"{ServiceId}/user_impersonation";
        static string Authority = "PASTE WS-FEDERATION SIGN-ON ENDPOINT";
        
        string[] _scopes => new string[] { Scope };
        private PublicClientApplication _clientApp = new PublicClientApplication(ClientId, Authority);
        private AuthenticationResult authResult;
        public PublicClientApplication ClientApp => _clientApp;
        public async Task LoginAsync()
        {
            var user = (await ClientApp.GetAccountsAsync()).FirstOrDefault();
            authResult = await ClientApp.AcquireTokenAsync(_scopes, user);
        }
        public async Task<string> CallAzureFunction(string url)
        {
            return await GetHttpContentWithToken(url, authResult.AccessToken);
        }
        public async Task<string> GetHttpContentWithToken(string url, string token)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;
            try
            {
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
