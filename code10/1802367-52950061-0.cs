    public interface IApplicationHttpClient
    {
        Task<HttpClient> GetClient();
    }
     public class ApplicationHttpClient : IApplicationHttpClient
        {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private HttpClient _httpClient = new HttpClient();
        public ApplicationHttpClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<HttpClient> GetClient()
        {
            string accessToken = string.Empty;
            // get the current HttpContext to access the tokens
            var currentContext = _httpContextAccessor.HttpContext;
            // get access token
            //accessToken = await currentContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            //should we renew access & refresh tokens?
            //get expires_at value
            var expires_at = await currentContext.GetTokenAsync("expires_at");
            //compare -make sure to use the exact date formats for comparison(UTC, in this case)
            if (string.IsNullOrWhiteSpace(expires_at) ||
                ((DateTime.Parse(expires_at).AddSeconds(-60)).ToUniversalTime() < DateTime.UtcNow))
            {
                accessToken = await RenewTokens();
            }
            else
            {
                //get access token
                accessToken = await currentContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            }
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                // set as Bearer token
                _httpClient.SetBearerToken(accessToken);
            }
            //api url
            _httpClient.BaseAddress = new Uri("https://localhost:44310/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return _httpClient;
        }
        public async Task<string> RenewTokens()
        {
            //get the current HttpContext to access the tokens
            var currentContext = _httpContextAccessor.HttpContext;
            //get the metadata from the IDP
            var discoveryClient = new DiscoveryClient("https://localhost:44329/");
            var metaDataResponse = await discoveryClient.GetAsync();
            //create a new token client to get new tokens
            var tokenClient = new TokenClient(metaDataResponse.TokenEndpoint, "mywebapp", "secret");
            //get the saved refresh token
            var currentRefreshToken = await currentContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
            //refresh the tokens
            var tokenResult = await tokenClient.RequestRefreshTokenAsync(currentRefreshToken);
            if (!tokenResult.IsError)
            {
                var updatedTokens = new List<AuthenticationToken>();
                updatedTokens.Add(new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.IdToken,
                    Value = tokenResult.IdentityToken
                });
                updatedTokens.Add(new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = tokenResult.AccessToken
                });
                updatedTokens.Add(new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = tokenResult.RefreshToken
                });
                var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResult.ExpiresIn);
                updatedTokens.Add(new AuthenticationToken
                {
                    Name = "expires-at",
                    Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                });
                //get authenticate result, containing the current principal & properties
                var currentAuthenticateResult = await currentContext.AuthenticateAsync("Cookies");
                //store the updated tokens
                currentAuthenticateResult.Properties.StoreTokens(updatedTokens);
                //sign in
                await currentContext.SignInAsync("Cookies", currentAuthenticateResult.Principal,
                    currentAuthenticateResult.Properties);
                //return the new access token
                return tokenResult.AccessToken;
            }
            throw new Exception("Problem encountered while refreshing tokens.", tokenResult.Exception);
        }
    }
