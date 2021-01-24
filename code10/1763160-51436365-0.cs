    public static class ServiceClientBase<T> where T : IRestClient
    {
        private static T _client;
    
        public static void Initialize(T restClient)
        {
            _client = restClient;
        }
    
        public static T GetClient()
        {
            return _client;
        }
    }
