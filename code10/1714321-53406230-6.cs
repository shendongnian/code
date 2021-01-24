	public class BearerTokenRequestHandler : DelegatingHandler
    {
        private readonly IServiceProvider serviceProvider;
        public BearerTokenRequestHandler(IServiceProvider serviceProvider, HttpMessageHandler innerHandler = null)
        {
            this.serviceProvider = serviceProvider;
            InnerHandler = innerHandler ?? new HttpClientHandler();
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
            var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            request.Headers.Authorization =new AuthenticationHeaderValue("Bearer", accessToken);
            var result = await base.SendAsync(request, cancellationToken);
            return result;
        }
    }
