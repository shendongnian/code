    public class HeaderHandler: DelegatingHandler
    {
        public HeaderHandler()
        {
        }
        public HeaderHandler(DelegatingHandler innerHandler): base(innerHandler)
        {
        }
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("CUSTOM-HEADER","CUSTOM HEADER VALUE");
            return await base.SendAsync(request, cancellationToken);
        }
    }
