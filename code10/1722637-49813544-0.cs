	protected byte[] ReceiveBodyData(Socket handler, int bodyLength)
	{
		// we know how many bytes to expect, so we create an appropriate array and keep track 
		// of how many bytes we've received.
		var result = new byte[bodyLength];
		var totalBytesReceived = 0;
		while (true)
		{
            // The bug is in the line below
			var bytesCount = handler.Receive(result, totalBytesReceived, bodyLength - totalBytesReceived, SocketFlags.None);
			if (totalBytesReceived >= bodyLength)
			{
				return result;
			}
		}
	}
