    public class CustomTokenCheckMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (HasMyTokenExpired())
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    ReasonPhrase = "",
                    Content = new StringContent("Test") // See HttpContent for more https://msdn.microsoft.com/en-us/library/system.net.http.httpcontent(v=vs.118).aspx
                };
            }
    
            return await base.SendAsync(request, cancellationToken);
        }
    
        public bool HasMyTokenExpired()
        {
            //Your custom logic here
            return true;
        }
    }
