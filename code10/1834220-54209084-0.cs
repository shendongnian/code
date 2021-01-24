    static void Main(string[] args)
		{
			listener = new TcpListener(localAddr, port);
			var clientSocket = default(TcpClient);
			listener.Start();
			var counter = 0;
			while (true)
			{
				clientSocket = listener.AcceptTcpClient();
				var client = new ConnectedDevice();
				client.startClient(clientSocket, counter.ToString(), sqlConnString);
			}
		}
