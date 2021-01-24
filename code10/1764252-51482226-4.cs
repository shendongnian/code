    public class YNABClient
    {
        private static YNABClient instance;
        private HttpClient client;
        private HttpClientHandler handler;
        private YNABClient(HttpClientHandler _handler = null)
        {
            handler = _handler ?? new HttpClientHandler();
            client = new HttpClient(_handler);
        }
        public static YNABClient GetInstance(HttpClientHandler _handler = null)
        {
            return instance ?? (instance = new YNABClient(_handler));
        }
        ......
    }
