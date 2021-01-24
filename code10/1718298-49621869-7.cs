    public static class HttpClientAccessor {
       public static Func<HttpClient> ValueFactory = () => {
          var client = new HttpClient();
    
          client.BaseAddress = new Uri("https://apiUrl.com");
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
          client.DefaultRequestHeaders.TryAddWithoutValidation("APIAccessToken", "token1");
          client.DefaultRequestHeaders.TryAddWithoutValidation("UserToken", "token2");
    
           return client;
       };
    
       private static Lazy<HttpClient> client = new Lazy<HttpClient>(ValueFactory);
    
       public static HttpClient HttpClient {
          get { return client.Value; }
       }
    }
