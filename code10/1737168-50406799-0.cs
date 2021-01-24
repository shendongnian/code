    public static void Main(string[] args) {
        HttpClient c = new HttpClient(new MyHttpClientHandler());
        c.DefaultRequestHeaders.Add("X-Test", "1");
        var res = c.GetAsync("http://google.com").Result;
    }
    class MyHttpClientHandler : HttpClientHandler {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            // check for your endpoint
            if (request.RequestUri.Host == "google.com") {
                // remove
                request.Headers.Remove("X-Test");
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
