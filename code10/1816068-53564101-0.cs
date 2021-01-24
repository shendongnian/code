    class MyHandler : DelegatingHandler
    {
        public MyHandler()
        {
            InnerHandler = new SocketsHttpHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip
            };
        }
    }
----------
    var client = _factory.CreateDefaultClient(new MyHandler());
