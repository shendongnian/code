    class XmlRpcTest : XmlRpcClient
    {
        private static Uri remoteHost = new Uri("http://localhost:8888/");
        [RpcCall]
        public string GetTest()
        {
            return DoRequest(remoteHost, 
                CreateRequest("getTest", new object[] {}));
        }
    }
