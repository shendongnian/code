    public class AuthorizingHandler : DelegatingHandler
    {
        private readonly string _headerValue;
        public AuthorizingHandler(HttpMessageHandler inner, string headerValue)
            : base(inner)
        {
            _headerValue = headerValue;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization", _headerValue);
            return base.SendAsync(request, cancellationToken);
        }
    }
