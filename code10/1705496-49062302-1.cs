        private static async Task<string> GetAccessTokenAsync()
        {
            string tenantId = "<tenantId>";
            string clientId = "<clientId>";
            string clientSecrets = "<clientSecrets>";
            Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult result = null;
            var context = new AuthenticationContext(String.Format("https://login.windows.net/{0}", tenantId)); 
            var authParam = new PlatformParameters(PromptBehavior.Never, null);
            var result = await context.AcquireTokenAsync(
                    "https://graph.microsoft.com"
                    , new Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential(clientId, clientSecrets)
                    );
            return result.AccessToken;
        }
    //initialize the GraphServiceClient instance
	var graphClient = new GraphServiceClient(
				"https://graph.microsoft.com/v1.0",
				new DelegateAuthenticationProvider(
					async (requestMessage) =>
					{
						var token = await GetAccessTokenAsync();
						requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
					}));
