    private static GraphServiceClient GetClient(string accessToken, IHttpProvider provider = null)
    {
            var delegateAuthProvider = new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
                return Task.FromResult(0);
            });
            var graphClient = new GraphServiceClient(delegateAuthProvider, provider ?? HttpProvider);
            return graphClient;
     }
