	public class CustomHttpResponse : IHttpActionResult
    {
        public HttpStatusCode StatusCode;
        public HttpContent Content;
        public CustomHttpResponse(HttpStatusCode httpStatusCode, HttpContent httpContent)
        {
            StatusCode = httpStatusCode;
            Content = httpContent;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage(StatusCode);
			httpResponse.Content = Content;
			return Task.FromResult(httpResponse);
        }
    }
	
