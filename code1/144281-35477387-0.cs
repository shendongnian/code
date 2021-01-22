        static void Main(string[] args)
        {
            Console.Title = "Socket Server";
            Console.WriteLine("Listening for messages...");
        Socket serverSock = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);
        IPAddress serverIP = IPAddress.Any;
        IPEndPoint serverEP = new IPEndPoint(serverIP, 33367);
        SocketPermission perm = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "98.112.235.18", 33367);
        perm.Assert();
        serverSock.Bind(serverEP);
        serverSock.Listen(10);
        while (true)
        {
            Socket connection = serverSock.Accept();
            Byte[] serverBuffer = new Byte[8];
            String message = String.Empty;
            while (connection.Available > 0)
            {
                int bytes = connection.Receive(
                    serverBuffer,
                    serverBuffer.Length,
                    0);
                message += Encoding.UTF8.GetString(
                    serverBuffer,
                    0,
                    bytes);
            }
            Console.WriteLine(message);
            connection.Close();
        }
    }
