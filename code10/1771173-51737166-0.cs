    public class MyCacheClass
    {
        //Store the list of users/requests
        static private ConcurrentDictionary<string, Task<HttpResponseMessage>> _cache = new ConcurrentDictionary<string, Task<HttpResponseMessage>>();
        //Get from the ConcurrentDictionary or add if it's not there
        public async Task<HttpResponseMessage> GetUser(string key)
        {
            return await _cache.GetOrAdd(key, GetResponse(key));
        }
        //You just to implement this method, potentially in a subclass, to get the data
        protected virtual async Task<HttpResponseMessage> GetResponse(string key)
        {
            var httpClient = new HttpClient();
            var url = string.Format(@"http://www.google.com?q={0}", key);
            return await httpClient.GetAsync(url);
        }
    }
