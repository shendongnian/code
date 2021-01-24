    public class AmpersandHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var uriString = request.RequestUri.OriginalString;
            if (uriString.Last() == '&')
            {
                request.RequestUri = new Uri(uriString.Substring(0, uriString.Length - 1));
                //return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unparseable URI - Trailing &");
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
