    internal class OCRServiceConfiguration : IOCRServiceConfiguration
    {
        public OCRServiceConfiguration(string apiKey)
        {
            ApiKey = apiKey;
        }
        public string ApiKey { get; }
    }
