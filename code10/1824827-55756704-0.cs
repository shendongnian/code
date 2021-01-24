    class Program
    {
        protected static WebSocketServer wsServer { get; private set; }
        static void Main(string[] args)
        {
            wsServer = new WebSocketServer();
            var config = new ServerConfig();
            config.Port = 8088;
            config.Ip = "Any";
            config.Mode = SocketMode.Tcp;
            config.MaxConnectionNumber = 1000;
            config.Name = "ChatServer";
            config.ReceiveBufferSize = 16384;
            config.SendBufferSize = 1024;
            var rootConfig = new RootConfig() { };
            var ret = wsServer.Setup(rootConfig, config, null, null, new ConsoleLogFactory(), null, null);
            if (!ret)
            {
                throw new Exception("Server is not setup correctly");
            }
            else
            {
                wsServer.NewSessionConnected += wsServer_NewSessionConnected;
                wsServer.NewMessageReceived += wsServer_NewMessageReceived;
                wsServer.NewDataReceived += wsServer_NewDataReceived;
                wsServer.SessionClosed += wsServer_SessionClosed;
                wsServer.Start();
                int maxConn = wsServer.Config.MaxConnectionNumber;
                Console.WriteLine("Server is running on port " + config.Port + ". Max Connection is " + maxConn.ToString() + ". Press Enter to exit...");
                Console.ReadKey();
                wsServer.Stop();
            }
        }
        static void wsServer_NewSessionConnected(WebSocketSession session)
        {
            Console.WriteLine("NewSessionConnected");            
        }
        static void wsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            Console.WriteLine("sessionClosed");
        }
        static void wsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            Console.WriteLine("NewDataReceived");
        }
        static void wsServer_NewMessageReceived(WebSocketSession session, string value)
        {
            Console.WriteLine("NewMessageReceived: " + value);
        }
    }
