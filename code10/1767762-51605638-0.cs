    //create a service that caches HttpClient based on url
    public interface IHttpClientService
    {
        IHttpClient GetClient(string baseHref);
        void AddClient(HttpClient client, string baseHref);
    }
    //implement your interface
    public class HttpClientService : IHttpClientService
    {
        private readonly ConcurrentDictionary<string, IHttpClient> _httpClients;
        public HttpClientService()
        {
            _httpClients = new ConcurrentDictionary<string, IHttpClient>();
        }
        public void AddClient(HttpClient client, string baseHref)
        {
            _httpClients.
                    .AddOrUpdate(baseHref, client, (key, existingHttpClient) => existingHttpClient);
        }
        public IHttpClient GetClient(string baseHref)
        {
            if (_httpClients.TryGetValue(baseHref, out var client))
                return client;
            return null;
        }
    }
    //register as singleton Startup.cs
    services.AddSingleton<IHttpClientService, HttpClientService>();
    //inject into Controller
    [HttpGet]
    public async Task<string> Get(string transformation = "xml")
    {
        const string url = @"http://baseurl:port/my/resource/is/there.do?transformation=" + transformation;
 
        var httpClient = _httpService.GetClient(url);
        if(httpClient == null)
        {
            httpClient = new HttpClient(url);
            const string authScheme = @"Basic";
            const string name = @"myUserName";
            const string password = @"myPassword";
            var authBytes = Encoding.ASCII.GetBytes($@"{name}:{password}");
            var auth64BaseString = Convert.ToBase64String(authBytes);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authScheme, auth64BaseString);
            const string fileName = @"input.xml";
            var inputBytes = File.ReadAllBytes(fileName);
            var byteArrayContent = new ByteArrayContent(inputBytes);
            const string formDataKey = @"""file""";
            const string formDataValue = @"""input.xml""";
            var multipartFormDataContent = new MultipartFormDataContent()
            {
                { byteArrayContent, formDataKey, formDataValue }
            };
        
            _httpClient.AddClient(httpClient, url);
        }
        else
        {
          //You can cache your MultipartFormDataContent in MemoryCache or same cache as HttpClient
         //Get MultipartFormDataContent from cache and
        }
       
        var response = await httpClient.PostAsync(url, multipartFormDataContent);
        return await response.Content.ReadAsStringAsync();
    }
