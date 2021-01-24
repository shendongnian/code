    public class TestHandler : DelegatingHandler
    {
        private Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handler;
        
        public TestHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handler)
        {
            _handler = handler;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _handler(request, cancellationToken);
        }
        public static Task<HttpResponseMessage> OK()
        {
            return Task.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.OK));
        }
        public static Task<HttpResponseMessage> BadRequest()
        {
            return Task.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.BadRequest));
        }
    }
