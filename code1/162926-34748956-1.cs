    public class IMyAttributeStore : IAttributeStore
    {
        ChannelFactory<IMyBackendInterface> factory;
        public IMyAttributeStore()
        {
        }
        public IAsyncResult BeginExecuteQuery(string query, string[] parameters, AsyncCallback callback, object state)
        {
            AsyncResult queryResult = new TypedAsyncResult<string[][]>(callback, state);
            var client = factory.CreateChannel();
            CallState cs = new CallState(client, queryResult);
            Request rq = new Request();
            client.BeginGetUserRoles(rq, new AsyncCallback(AsyncCallCallback), cs);
            return cs.result;
        }
        public string[][] EndExecuteQuery(IAsyncResult result)
        {
            return TypedAsyncResult<string[][]>.End(result);
        }
        // Initialize state here.
        public void Initialize(Dictionary<string, string> config)
        {
            var endpoint = config["endpointConfigurationName"];
            factory = new ChannelFactory<IMyBackendInterface>(endpoint);
        }
        void AsyncCallCallback(IAsyncResult result)
        {
            CallState cs = (CallState)result.AsyncState;
            Response data = cs.client.EndGetUserRoles(result);
            List<string[]> claimData = new List<string[]>();
            foreach (var val in data.Values)
                claimData.Add(new string[1] { val });
            string[][] retVal = claimData.ToArray();
            TypedAsyncResult<string[][]> queryResult = (TypedAsyncResult<string[][]>)cs.result;
            queryResult.Complete(retVal, false);
        }
    }
    class CallState
    {
        public IMyBackendInterface client;
        public AsyncResult result;
        public CallState(IMyBackendInterface c, AsyncResult r)
        {
            client = c;
            result = r;
        }
    }
