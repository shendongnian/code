    public sealed class MyServiceConfiguration
    {
        public readonly string ApiKey;
        public MyServiceConfiguration(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey)) throw new ArgumentException(...);
            this.ApiKey = apiKey;
        }
    }
