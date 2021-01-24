        string organizationUrl = "https://yourcrm.dynamics.com";
        string appKey = "*****";
        string aadInstance = "https://login.microsoftonline.com/";
        string tenantID = "myTenant.onmicrosoft.com";
        string clientId = "UserGUID****";
        public Task<String> SendData()
        {
            return AuthenticateWithCRM();
        }
        public async Task<String> AuthenticateWithCRM()
        {
            ClientCredential clientcred = new ClientCredential(clientId, appKey);
            AuthenticationContext authenticationContext = new AuthenticationContext(aadInstance + tenantID);
            AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(organizationUrl, clientcred);
            using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(organizationUrl);
                    .
                    .
                 }
        }
