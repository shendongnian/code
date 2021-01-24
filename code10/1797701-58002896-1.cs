    private static ServiceClientCredentials AuthenticateAzure
        (string domainName, string clientID, string clientSecret)
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            var clientCredential = new ClientCredential(clientID, clientSecret);
            return ApplicationTokenProvider.LoginSilentAsync(domainName, clientCredential).Result;
        }
