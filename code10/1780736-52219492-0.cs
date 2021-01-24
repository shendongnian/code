    public class myServiceCredentials : ServiceClientCredentials{
    private string AuthenticationToken { get; set; }
    public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            var authenticationContext = new 
       AuthenticationContext("https://login.windows.net/{tenantID}");
            var credential = new ClientCredential(clientId: "xxxxx-xxxx-xx-xxxx-xxx", 
      clientSecret: "{clientSecret}");
            var result = authenticationContext.AcquireToken(resource: 
            "https://management.core.windows.net/", clientCredential: credential);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }
            AuthenticationToken = result.AccessToken;
        }
    }
