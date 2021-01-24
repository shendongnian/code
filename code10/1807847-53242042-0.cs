    public interface IHttpClientManager
    {
        public HttpClient WithRedirects { get; }
        public HttpClient WithoutRedirects { get; }
    }
