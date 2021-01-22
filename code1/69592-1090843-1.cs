    class XmlRpcTest : XmlRpcClient
    {
        private static Uri remoteHost = new Uri("http://localhost:8888/");
        [RpcCall]
        public string GetTest()
        {
            return (string)DoRequest(remoteHost, 
                CreateRequest("getTest", null));
        }
    }
