     public class CustomCredentials : ServiceClientCredentials
        {
            private string AuthenticationToken { get; set; }
    
            public override void InitializeServiceClient<T>(ServiceClient<T> client)
            {
                var authenticationContext =
                    new AuthenticationContext("https://login.windows.net/yourtenantId");
                var credential = new ClientCredential("clientid", clientSecret: "secret key");
    
                var result = authenticationContext.AcquireTokenAsync("https://management.azure.com/",
                    credential).Result;
    
                if (result == null)
                {
                    throw new InvalidOperationException("Failed to obtain the JWT token");
                }
    
                AuthenticationToken = result.AccessToken;
            }
        }
