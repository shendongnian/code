    using System.Net.Http;
    using System.Threading.Tasks;
    
    class HttpClientHelper
    {
        private static HttpClient _httpClient;
    
        public static async Task<bool> DoesFileExist(string url)
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
            }
    
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url))
            {
                using (HttpResponseMessage response = await _httpClient.SendAsync(request))
                {
                    return response.StatusCode == System.Net.HttpStatusCode.OK;
                }
            }
        }
    }
