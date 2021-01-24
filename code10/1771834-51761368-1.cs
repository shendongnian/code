    class Program
    {
        static void Main(string[] args)
        {
            var invoker = new JsonMockInvoker();
            var jsonObj = invoker.Get<SomeClass>("API_URL1");
            var jsonObj2 = invoker.Get<string[]>("API_URL2");
        }
    }
    
    class SomeClass
    {
        public string Name { get; set; }
        //other properties
    }
    
    public class JsonMockInvoker:JsonInvoker
    {
        public override string InvokeRest(string url)
        {
            if (url == "API_URL1")
                return "{\"Name\": \"Apple\",\"Expiry\": \"2008-12-28T00:00:00\",\"Price\": 3.99,\"Sizes\": [\"Small\",\"Medium\",\"Large\"]}";
            if (url == "API_URL2")
                return "[\"Name=xyz, Id=1, Version=1\", \"Name=abc, Id=1, Version=2\", \"Name=hgf, Id=1, Version=3\", \"Name=utgds, Id=1, Version=4\", \"Name=kfgf, Id=2, Version=1\"]";
            throw new NotImplementedException();
        }
    }
    
    public class JsonInvoker
    {
        public T Get<T>(string requestUri)
        {
            var result = InvokeRest(requestUri);
            return result != null ? JsonConvert.DeserializeObject<T>(result) : default(T);
        }
    
        public virtual string InvokeRest(string url)
        {
            using (var handler = new HttpClientHandler { Credentials = CredentialCache.DefaultNetworkCredentials })
            using (var httpClient = CreateNewRequest(handler))
            {
                var httpTask = httpClient.GetAsync(url);
                var response = httpTask.Result;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            return null;
        }
    
        private HttpClient CreateNewRequest(HttpClientHandler handler)
        {
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
