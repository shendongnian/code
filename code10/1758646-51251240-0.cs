    public class TextResult : IHttpActionResult {
        string message;
        HttpRequestMessage request;
        public TextResult(string message, HttpRequestMessage request) {
            this.message = message;
            this.request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            var response = request.CreateResponse(HttpStatusCode.OK, message);
            return Task.FromResult(response);
        }
    }
