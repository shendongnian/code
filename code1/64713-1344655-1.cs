	public void OnClientConnect(IAsyncResult asyn)
	{
		try
		{
			TcpListener listener = (TcpListener)ar.AsyncState;
			System.Net.Sockets.TcpClient client = listener.EndAcceptTcpClient(ar);
			IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
			if (clientEndPoint.Address == new IPAddress("127.0.0.1"))
				throw new InvalidOperationException();
