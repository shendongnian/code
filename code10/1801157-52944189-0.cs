    public abstract class HttpBaseRequest : IHttpRequest
    {
        protected HttpBaseRequest(string rawUrl)
        {
            RawUrl = rawUrl;
        }
        public string RawUrl{ get; protected set; }
        public string GetJsonFromUrl(string url)
        {
            return "";
        }
    }
    public class HttpDataRequest : HttpBaseRequest
    {
        public HttpDataRequest(string rawUrl) : base(rawUrl) { }
    }
    public class UrlMetadataResolver : HttpBaseRequest
    {
        public UrlMetadataResolver(string rawUrl) : base(rawUrl) { }
    }
