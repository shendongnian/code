      public static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client,
        string requestUri, object requestObject, Dictionary<string, string> requestHeaders = null,
        int? timeoutMilliSeconds = null)
        {
          var jsonContent = JsonConvert.SerializeObject(requestObject);
    
          var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
    
          return await SendAsync(client, requestUri, HttpMethod.Post,
              requestContent, requestHeaders, timeoutMilliSeconds);
        }
    
    
        public static async Task<HttpResponseMessage> SendAsync(
        this HttpClient client,
        string requestUri, HttpMethod httpMethod, HttpContent requestContent = null,
        Dictionary<string, string> requestHeaders = null, int? timeoutMilliSeconds = null)
        {
          var httpRequestMessage = new HttpRequestMessage
          {
            RequestUri = new Uri(requestUri),
            Method = httpMethod,
            Content = requestContent
          };
    
          if (requestHeaders != null)
          {
            foreach (var requestHeader in requestHeaders)
            {
              httpRequestMessage.Headers.Add(requestHeader.Key, requestHeader.Value);
            }
          }
    
          if (timeoutMilliSeconds.HasValue)
          {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(new TimeSpan(0, 0, 0, 0, timeoutMilliSeconds.Value));
            return await client.SendAsync(httpRequestMessage, cts.Token);
          }
          else
          {
            return await client.SendAsync(httpRequestMessage);
          }
        }
