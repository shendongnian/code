    public class CommsClass
    {
        private HttpClient _httpClient;
        public CommsClass(NetworkCredential credentials)
        {
             var handler = new HttpClientHandler { Credentials = credentials };
             _httpclient = new HttpClient(handler);
        }
        public HttpResponseMessage Execute(HttpRequestMessage message)
        {
            var response = _httpClient.SendAsync(message).Result;
            return response;
        }
    }
