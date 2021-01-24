    internal class ComputerVisionClientFactory : IComputerVisionClientFactory
    {
        public GetClient(string apiKey)
        {
            return new ComputerVisionClient(new ApiKeyServiceClientCredentials(apiKey))
            {
                Endpoint = "https://westeurope.api.cognitive.microsoft.com"
            };
        }
    }
    // ...
    internal class OCRService : IOCRService, IDisposable
    {
        public OCRService(string apiKey, IComputerVisionClientFactory clientFactory)
        {
            _client = clientFactory.GetClient(apiKey);
        }
    }
