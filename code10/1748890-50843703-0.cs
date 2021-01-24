    public class HttpFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new CustomMessageHandler();
        }
    }
    public class CustomMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content = await request.Content.ReadAsByteArrayAsync();
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
     FlurlHttp.Configure(settings =>
     {
         settings.HttpClientFactory = new HttpFactory();
     });
