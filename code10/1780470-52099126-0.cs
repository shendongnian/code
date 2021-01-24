    public interface IWebService {
        Task<T> PostRequestAsync<T>(string endpoint, Object obj) where T : class;
        Task<T> GetRequestAsync<T>(string endpoint) where T : class;
    }
    public class WebService : IWebService {
        static HttpClient client = new HttpClient();
        public virtual async Task<T> PostRequestAsync<T>(string requestUri, Object obj) where T : class {
            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "");
            try {
                var response = await client.PostAsync(requestUri, content); // Test case fails here
                if (response.IsSuccessStatusCode) {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                return default(T);
            } catch (WebException) {
                throw;
            }
        }
        public async Task<T> GetRequestAsync<T>(string requestUri) where T : class {
            try {
                var response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode) {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(data);
                }
                return default(T);
            } catch (WebException) {
                throw;
            }
        }
    }
