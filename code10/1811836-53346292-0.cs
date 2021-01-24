    public class HtmlActionResult : IHttpActionResult
    {
        public HtmlActionResult (HttpRequestMessage request, string content)
        {
            Request = request;
            Content= content;
        }
    
        public string Content { get; private set; }
        public HttpRequestMessage Request { get; private set; }
    
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(ExecuteResult());
        }
    
        public HttpResponseMessage ExecuteResult()
        {
            var response = new HttpResponseMessage();
    
            if (!string.IsNullOrWhiteSpace(Content))
                response.Content = new StringContent(Content, Encoding.UTF8, "text/html");
    
            response.RequestMessage = Request;
            return response;
        }
    }
