    public class BatchRequest
    {
        private Dictionary<string, IBaseRequest> _queriesTable = new Dictionary<string, IBaseRequest>();
        private Dictionary<string,Type> _resultsTable = new Dictionary<string, Type>();
        public KeyValuePair<IBaseRequest, Type> this[string queryId]
        {
            get
            {
                return new KeyValuePair<IBaseRequest,Type>(_queriesTable[queryId], _resultsTable[queryId]);
            }
        }
        public void AddQuery(IBaseRequest query, Type entityType)
        {
            var queryId = Guid.NewGuid().ToString();
            _resultsTable[queryId] = entityType;
            _queriesTable[queryId] = query;
        } 
        /// <summary>
        /// Construct JSON batch request https://developer.microsoft.com/en-us/graph/docs/concepts/json_batching
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public HttpRequestMessage ToMessage(GraphServiceClient client)
        {
            var batchMessage = new HttpRequestMessage();
            batchMessage.RequestUri = new Uri("https://graph.microsoft.com/v1.0/$batch");
            batchMessage.Method = HttpMethod.Post;
            batchMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            dynamic payload = new ExpandoObject();
            payload.requests = _queriesTable.Select(kv =>
            {
                var message = kv.Value.GetHttpRequestMessage();
                dynamic request = new ExpandoObject();
                request.id = kv.Key; 
                request.method = message.Method.ToString();
                request.url = message.RequestUri.AbsoluteUri.Replace(client.BaseUrl,string.Empty);
                if(message.Content != null)
                    request.body = message.Content;
                
                request.headers = message.Headers.ToDictionary(x => x.Key, x => x.Value.FirstOrDefault());
                return request;
            });
            var jsonPayload = client.HttpProvider.Serializer.SerializeObject(payload);
            batchMessage.Content = new StringContent(jsonPayload,Encoding.UTF8,"application/json");
            return batchMessage;
        }
    }
