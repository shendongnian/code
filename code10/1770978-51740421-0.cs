        public class ApiClient : HttpClient
        {
        public Func<HttpResponseMessage, HttpResponseMessage> Action => (response) =>
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.ToString());
            }
            return response;
        };
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            var result = await base.GetAsync(requestUri);
            return Action(result);
        }
    
        }
