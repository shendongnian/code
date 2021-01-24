    class Client
    {
        private readonly UdpClient _serverClient;
        public Client(string host, int port)
        {
            _serverClient = new UdpClient(host,port);
        }
        public void Run()
        {
            try
            {
                _serverClient.BeginReceive(new AsyncCallback(ProcessCallback), null);
            }
            catch (Exception e)
            {
                Console.WriteLine("[CLIENT][ERR]: {0}", e);
                Console.WriteLine("[CLIENT][ERR]: Stopping...");
                return;
            }
            Console.WriteLine("[CLIENT]: Started");
            while (true)
            {
                string input = Console.ReadLine();
                if (input != null)
                {
                    if (input == "stop")
                    {
                        break;
                    }
                    byte[] bytesent = Encoding.ASCII.GetBytes(input);
                    _serverClient.Send(bytesent, bytesent.Length);
                    Console.WriteLine("[CLIENT]: Sent '{0}'", input);
                }
            }
        }
        private void ProcessCallback(IAsyncResult result)
        {
            var remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            var received = _serverClient.EndReceive(result, ref remoteIpEndPoint);
            try
            {
                ProcessReceived(received, remoteIpEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine("[CLIENT][ERR]: Error on processing: {0}", e);
            }
            _serverClient.BeginReceive(new AsyncCallback(ProcessCallback), null);
        }
        private void ProcessReceived(byte[] received, IPEndPoint remoteIpEndPoint)
        {
            Console.WriteLine("[CLIENT]: Receieved '{0}' from server.", Encoding.ASCII.GetString(received));
        }
    }
