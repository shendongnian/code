    public static class Service<TClient>
        where TClient : class, ICommunicationObject, IServiceClientFactory<TClient>, new()
    {
        public static TReturn Use<TReturn>(Func<TClient, TReturn> codeBlock)
        {
            TClient client = default(TClient);
            bool success = false;
            try
            {
                client = new TClient().DoSomethingWithClient();
                TReturn result = codeBlock(client);
                client.Close();
                success = true;
                return result;
            }
            finally
            {
                if (!success && client != null)
                {
                    client.Abort();
                }
            }
        }
    }
