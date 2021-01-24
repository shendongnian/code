    public GraphServiceClient GetAuthenticatedClient(string userId)
        {
            _graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(
            async requestMessage =>
            {
                // Passing tenant ID to the sample auth provider to use as a cache key
                var accessToken = await _authProvider.GetUserAccessTokenAsync(userId);
             ...
            }
            return _graphClient;
        }
