        	public bool UploadFile(string localFilePath, string remoteDirectory)
		{
			var fileName = Path.GetFileName(localFilePath);
			string content;
			using (var reader = new StreamReader(localFilePath))
				content = reader.ReadToEnd();
			var proxyAuthB64Str = Convert.ToBase64String(Encoding.ASCII.GetBytes(_proxyUserName + ":" + _proxyPassword));
			var sendStr = "PUT ftp://" + _ftpLogin + ":" + _ftpPassword
				+ "@" + _ftpHost + remoteDirectory + fileName + " HTTP/1.1\n"
				+ "Host: " + _ftpHost + "\n"
				+ "User-Agent: Mozilla/4.0 (compatible; Eradicator; dotNetClient)\n" + "Proxy-Authorization: Basic " + proxyAuthB64Str + "\n"
				+ "Content-Type: application/octet-stream\n"
				+ "Content-Length: " + content.Length + "\n"
				+ "Connection: close\n\n" + content;
			var sendBytes = Encoding.ASCII.GetBytes(sendStr);
			using (var proxySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
			{
				proxySocket.Connect(_proxyHost, _proxyPort);
				if (!proxySocket.Connected)
					throw new SocketException();
				proxySocket.Send(sendBytes);
				const int recvSize = 65536;
				var recvBytes = new byte[recvSize];
				proxySocket.Receive(recvBytes, recvSize, SocketFlags.Partial);
				var responseFirstLine = new string(Encoding.ASCII.GetChars(recvBytes)).Split("\n".ToCharArray()).Take(1).ElementAt(0);
				var httpResponseCode = Regex.Replace(responseFirstLine, @"HTTP/1\.\d (\d+) (\w+)", "$1");
				var httpResponseDescription = Regex.Replace(responseFirstLine, @"HTTP/1\.\d (\d+) (\w+)", "$2");
				return httpResponseCode.StartsWith("2");
			}
			return false;
		}
