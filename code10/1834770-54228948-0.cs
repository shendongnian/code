	var server = new Socket(SocketType.Stream, ProtocolType.Tcp);
	var client = new Socket(SocketType.Stream, ProtocolType.Tcp);
	/* Init the server socket */
	server.Bind(new IPEndPoint(IPAddress.Any, 19998));
	server.Listen(50);
	server.BeginAccept(ar =>
	{
		var server2 = server.EndAccept(ar);
		//server2.Close(); // Read will return 0
	},
	null);
	/* Init the client socket */
	client.Connect(IPAddress.Loopback, 19998);
	NetworkStream stream = new NetworkStream(client);
	//client.Close(); // Read will throw IOException
	var buf = new byte[128];
    int read = stream.Read(buf, 0, 128);
