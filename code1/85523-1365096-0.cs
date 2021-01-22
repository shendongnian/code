       Socket one = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket two = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
        one.Bind(ep);
        one.Listen(1);
        two.Connect("127.0.0.1", 12345);
        NetworkStream s = new NetworkStream(two);
        byte[] buffer = new byte[32];
        s.Read(buffer, 0, 32);
