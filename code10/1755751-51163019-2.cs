    static void Main(string[] args)
        {
            ScreenLogger screenLogger = new ScreenLogger();
            ServiceHost host = new ServiceHost(typeof(Service));
            screenLogger.Start(ba => ((Service)host.SingletonInstance).TaskResults = ba);
            host.AddServiceEndpoint(typeof(IService), new NetTcpBinding(), new Uri(@"net.tcp://localhost:8554/"));
            Console.WriteLine("Server start");
            host.Open();
            Console.ReadLine();
            host.Close();
        }
