    public class HttpWrapper 
    {
        private readonly HttpClient _cl;
        public HttpWrapper(HttpClient client)
        {
            _cl=client;
        }
        public string TestUrl = "aaa";
    }
