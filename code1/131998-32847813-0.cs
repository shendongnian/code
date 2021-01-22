    public static void SendFtpCommand()
	{
		var serverName = "[FTP_SERVER_NAME]";
		var port = 21;
		var userName = "[FTP_USER_NAME]";
		var password = "[FTP_PASSWORD]"
		var command = "SITE CHMOD 755 [FTP_FILE_PATH]";
		var tcpClient = new TcpClient();
		try
		{
			tcpClient.Connect(serverName, port);
			Flush(tcpClient);
			var response = TransmitCommand(tcpClient, "user " + userName);
			if (response.IndexOf("331", StringComparison.OrdinalIgnoreCase) < 0)
				throw new Exception(string.Format("Error \"{0}\" while sending user name \"{1}\".", response, userName));
			response = TransmitCommand(tcpClient, "pass " + password);
			if (response.IndexOf("230", StringComparison.OrdinalIgnoreCase) < 0)
				throw new Exception(string.Format("Error \"{0}\" while sending password.", response));
			response = TransmitCommand(tcpClient, command);
			if (response.IndexOf("200", StringComparison.OrdinalIgnoreCase) < 0)
				throw new Exception(string.Format("Error \"{0}\" while sending command \"{1}\".", response, command));
		}
		finally
		{
			if (tcpClient.Connected)
				tcpClient.Close();
		}
	}
	private static string TransmitCommand(TcpClient tcpClient, string cmd)
	{
		var networkStream = tcpClient.GetStream();
		if (!networkStream.CanWrite || !networkStream.CanRead)
			return string.Empty;
			
		var sendBytes = Encoding.ASCII.GetBytes(cmd + "\r\n");
		networkStream.Write(sendBytes, 0, sendBytes.Length);
		
		var streamReader = new StreamReader(networkStream);
		return streamReader.ReadLine();
	}
	private static string Flush(TcpClient tcpClient)
	{
		try
		{
			var networkStream = tcpClient.GetStream();
			if (!networkStream.CanWrite || !networkStream.CanRead)
				return string.Empty;
				
			var receiveBytes = new byte[tcpClient.ReceiveBufferSize];
			networkStream.ReadTimeout = 10000;
			networkStream.Read(receiveBytes, 0, tcpClient.ReceiveBufferSize);
			
			return Encoding.ASCII.GetString(receiveBytes);
		}
		catch
		{
			// Ignore all irrelevant exceptions
		}
		
		return string.Empty;
	}
