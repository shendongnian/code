    static HttpClient client = new HttpClient();
    public async Task<HttpResponseMessage> SendRequest(HttpRequestMessage httpRequest) {
        var response = await client.SendAsync(httpRequest);
        if(response == null) throw new InvalidOperationException();
        if (response.StatusCode == System.Net.HttpStatusCode.RequestTimeout ||
             response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
        ) {
            // DoSomething
        } else {
            // DoSomethingElse
        }
        return response;
     }
