    options.Scope.Add("User.ReadBasic.All");
    
    options.ResponseType = "code id_token";                
                    
    OnAuthorizationCodeReceived = async ctx =>
    {
        var request = ctx.HttpContext.Request;
        var currentUri = UriHelper.BuildAbsolute(request.Scheme, request.Host, request.PathBase, request.Path);
        var credential = new ClientCredential(ctx.Options.ClientId, ctx.Options.ClientSecret);
    
        var distributedCache = ctx.HttpContext.RequestServices.GetRequiredService<IDistributedCache>();
        string userId = ctx.Principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
    
        var cache = new DistributedTokenCache(distributedCache, userId);
    
        var authContext = new AuthenticationContext(ctx.Options.Authority, cache);
    
        var result = await authContext.AcquireTokenByAuthorizationCodeAsync(
            ctx.ProtocolMessage.Code,
            new Uri(currentUri),
            credential,
            ctx.Options.Resource);
    
        ctx.HandleCodeRedemption(result.AccessToken, result.IdToken);
    }
    
    services.AddDistributedMemoryCache();
    private async Task<string> GetAccessTokenAsync()
            {
                string authority = "https://login.microsoftonline.com/{0}/common/oauth2/v2.0/token";
                string tenantId = User.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
                authority = String.Format(authority, tenantId);
                string userId = (User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier"))?.Value;
                var cache = new DistributedTokenCache(_memoryCache, userId);
                var authContext = new AuthenticationContext(authority, cache);
                string graphResourceId = "https://graph.microsoft.com";
                string clientId = "XXX-XXX-XXX-XXX";
                string secret = "XXXX";
                var credential = new ClientCredential(clientId, secret);
                var result = await authContext.AcquireTokenSilentAsync(graphResourceId, credential, new UserIdentifier(userId, UserIdentifierType.UniqueId));
                return result.AccessToken;
            }
