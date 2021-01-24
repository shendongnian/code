    public class StripCharSetQuotesHandler : DelegatingHandler
    {
        
        public StripCharSetQuotesHandler(HttpClientHandler innerHandler) {
            : base(innerHandler)
        {
            // Nothing additional.
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var response = await base.SendAsync(request, cancellationToken);
    
            var contentType = response.Content.Headers.ContentType;
            if (contentType.CharSet?.Contains('"') == true) {
                contentType.CharSet = contentType.CharSet.Replace("\"", "");
            }
    
            return response;
        }
    
    }
