        public class XyzServiceClient
        {
            internal static HttpClient Client { get; set; } = new HttpClient();
            private readonly string _uri;
    
    
            public XyzServiceClient(string apiUrl)
            {
                _uri = apiUrl;
                Client.DefaultRequestHeaders.Clear();
            }
    
            public Xyz CallService(string username, string password)
            {
                var result = new Xyz();
                HttpResponseMessage response = CallXyzService(username, password);
                return ParseResponse(response, result);
            }
    
            internal HttpResponseMessage CallXyzService(string username, string password)
            {
                return Client.SendAsync(CreateHttpRequestMessage(username, password)).Result;
            }
    
            internal HttpRequestMessage CreateHttpRequestMessage(string username, string password)
            {
                var msg = new HttpRequestMessage(HttpMethod.Get, _uri);
                var authByteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
                msg.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authByteArray));
                return msg;
            }
    
            internal Xyz ParseResponse(HttpResponseMessage response, Xyz result)
            {
                if (response == null || !response.IsSuccessStatusCode)
                {
                    throw new Exception("Response from service indicates failure.");
                }
                
                using (HttpContent content = response.Content)
                {
                    string contentResult = content.ReadAsStringAsync().Result;
                    // do something to create your Xyz object using data in 
                    //contentResult
                     
                 }
                 return xyzResult;
                }
            }
