    public class ResourceGatewayClient : IApiClient
    {
        private static HttpClient _client;
        public HttpClient Client => _client;
        public ResourceGatewayClient(IHttpContextAccessor contextAccessor)
        {
            if (_client == null)
            {
                _client = new HttpClient(new ResourceGatewayMessageHandler(contextAccessor));
                //configurate default base address
                _client.BaseAddress = "https://gateway.domain.com/api";
            }
        }
    }
