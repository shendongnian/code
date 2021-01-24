    public class ResourceGatewayMessageHandler : HttpClientHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
    
        public ResourceGatewayMessageHandler(IHttpContextAccessor context)
        {
            _contextAccessor = context;
        }
    
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Retrieve acces token from token store
            var accessToken = await _contextAccessor.HttpContext.GetTokenAsync("access_token");
    
            //Add token to request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    
            //Execute request
            var response = await base.SendAsync(request, cancellationToken);
    
            //When 401 user is probably not logged in any more -> redirect to login screen
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ApiAuthenticationException();
            }
    
            //When 403 user probably does not have authorization to use endpoint -> show error page
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new ApiAuthorizationException();
            }
    
            return response;
        }
    
    }
