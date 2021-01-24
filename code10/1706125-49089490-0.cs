    /// <summary>
    /// Extended SQlite Store which can log operations happen in the SQLite database
    /// </summary>
    public class MobileServiceSQLiteStoreWithLogging : MobileServiceSQLiteStore
    {
        private bool logResults;
        private bool logParameters;
        public MobileServiceSQLiteStoreWithLogging(string fileName, bool logResults = false, bool logParameters = false)
            : base(fileName)
        {
            this.logResults = logResults;
            this.logParameters = logParameters;
        }
        protected override IList<JObject> ExecuteQueryInternal(string tableName, string sql,
            IDictionary<string, object> parameters)
        {
            Debug.WriteLine(sql);
            if (logParameters)
                PrintDictionary(parameters);
            var result = base.ExecuteQueryInternal(tableName, sql, parameters);
            if (logResults && result != null)
            {
                foreach (var token in result)
                    Debug.WriteLine(token);
            }
            return result;
        }
        protected override void ExecuteNonQueryInternal(string sql, IDictionary<string, object> parameters)
        {
            Debug.WriteLine(sql);
            if (logParameters)
                PrintDictionary(parameters);
            base.ExecuteNonQueryInternal(sql, parameters);
        }
        private void PrintDictionary(IDictionary<string, object> dictionary)
        {
            if (dictionary == null)
                return;
            foreach (var pair in dictionary)
                Debug.WriteLine("{0}:{1}", pair.Key, pair.Value);
        }
    }
    /// <summary>
    /// Message Handler which enable to pass the customer headers as well as logging the Request, Response etc happen via the Azure Mobile client
    /// </summary>
    public class CustomAzureClientMessageHandler : DelegatingHandler
    {
        private bool logRequestResponseBody;
        public CustomAzureClientMessageHandler(bool logRequestResponseBody = false)
        {
            this.logRequestResponseBody = logRequestResponseBody;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Debug.WriteLine("Request is being sent: {0} {1}", request.Method, request.RequestUri.ToString());
            if (logRequestResponseBody && request.Content != null)
            {
                var requestContent = await request.Content.ReadAsStringAsync();
                Debug.WriteLine(requestContent);
            }
            Debug.WriteLine("HEADERS in the request");
            foreach (var header in request.Headers)
            {
                Debug.WriteLine(string.Format("{0}:{1}", header.Key, string.Join(",", header.Value)));
            }
            var response = await base.SendAsync(request, cancellationToken);
            Debug.WriteLine("Response from server: {0}", response.StatusCode);
            if (logRequestResponseBody)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseContent);
            }
            return response;
        }
    }
