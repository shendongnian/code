    class ConnectedDevice
	{
		private TcpClient _clientSocket;
		private string _clientNumber;
		private string _sqlConnString;
		public void startClient(TcpClient clientSocket, string clientNumber, string sqlConnString)
		{
			_clientSocket = clientSocket;
			_clientNumber = clientNumber;
			_sqlConnString = sqlConnString;
			var ctThread = new Thread(ProcessClient);
			ctThread.Start();
		}
		private void ProcessClient()
		{
			while (_clientSocket.Connected)
			{
				try
				{
					Byte[] bytes = new Byte[_clientSocket.ReceiveBufferSize];
					var networkStream = _clientSocket.GetStream();
					networkStream.ReadTimeout = 10000;
					int i;
					while ((i = networkStream.Read(bytes, 0, bytes.Length)) != 0)
					{
						var data = System.Text.Encoding.ASCII.GetString(bytes, 0, i).Replace("-", "");
						byte[] sendBytes;
						Console.WriteLine(data);
						string sLogin1 = "7E81000013014185000008000000000054523230313731303138303930303137497E";
						sendBytes = Encoding.ASCII.GetBytes(sLogin1);
						networkStream.Write(sendBytes, 0, sendBytes.Length);
						networkStream.Flush();
					}
				}
				catch (Exception ex)
				{
				}
			}
		}
	}
