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
    static class Program
    {
        static void Main(string[] args)
        {
            XmlRpcTest test = new XmlRpcTest();
            Console.WriteLine(test.GetTest());
        }
    }
