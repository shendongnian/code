    public class YNABClient
    {
        private static YNABClient instance;
        private HttpClient client;
        private HttpMessageHandler handler;
        private YNABClient(HttpMessageHandler _handler = null)
        {
            handler = _handler ?? new HttpClientHandler();
            client = new HttpClient(_handler);
        }
        public static YNABClient GetInstance(HttpMessageHandler _handler = null)
        {
            return instance ?? (instance = new YNABClient(_handler));
        }
        ......
    }
