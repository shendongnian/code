	public override int Read(byte [] buffer, int offset, int size)
	{
		if (disposed)
			throw new ObjectDisposedException("Stream has been closed");
			try
		{
			int startTickCount = Environment.TickCount;
			int received = 0;  // how many bytes is already received
			do
			{
				if (Environment.TickCount > startTickCount + readTimeout)
					throw new SocketException(10060);
				try
				{
					received += socket.Receive(buffer, offset + received,
						size - received, SocketFlags.None);
				}
				catch (SocketException ex)
				{
					if (ex.ErrorCode == 10035 ||
						ex.ErrorCode == 10036 ||
						ex.ErrorCode == 10055)
					{
						// socket buffer is probably empty, wait and try again
						Thread.Sleep(30);
					}
					else
						throw;  // any serious error occurr
				}
			} while (received < size);
			return received;
		}
		catch (EndOfStreamException)
		{
			// connection broken
			throw new SocketException(10004);
		}
	}
