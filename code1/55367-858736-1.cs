    // copied from Mono, because CF lacks this enum
    enum SocketError
    {
    	IOPending = 997,
    	NoBufferSpaceAvailable = 10055,
    	TimedOut = 10060,
    	WouldBlock = 10035
    }
    // milliseconds
    int receiveTimeout = 20000;
    int sendTimeout = 20000;
    public override int Read(byte[] buffer, int offset, int size)
    {    
    	int startTickCount = Environment.TickCount;
    	int received = 0;
    	do
    	{
    		List<Socket> sock = new List<Socket>(new Socket[] {socket});
    		Socket.Select(sock, null, null, receiveTimeout*1000 + 1);
    		if (Environment.TickCount > startTickCount + receiveTimeout)
    			throw new SocketException((int) SocketError.TimedOut);
    		try
    		{
    			received += socket.Receive(buffer, offset + received,
    				size - received, SocketFlags.None);
    		}
    		catch (SocketException ex)
    		{
    			if (ex.ErrorCode == (int) SocketError.WouldBlock ||
    			    ex.ErrorCode == (int) SocketError.IOPending ||
    			    ex.ErrorCode == (int) SocketError.NoBufferSpaceAvailable)
    			{
    				// socket buffer is probably empty, wait and try again
    				Thread.Sleep(30);
    			}
    			else
    				throw; // any serious error occurr
    		}
    	} while (received < size);
    	return received;
    }
    public override void Write(byte[] buffer, int offset, int size)
    {
    	int startTickCount = Environment.TickCount;
    	int sent = 0;
    	do
    	{
    		List<Socket> sock = new List<Socket>(new Socket[] {socket});
    		Socket.Select(null, sock, null, sendTimeout*1000 + 1);
    		if (Environment.TickCount > startTickCount + sendTimeout)
    			throw new SocketException((int) SocketError.TimedOut);
    		try
    		{
    			sent += socket.Send(buffer, offset + sent,
    				size - sent, SocketFlags.None);
    		}
    		catch (SocketException ex)
    		{
    			if (ex.ErrorCode == (int) SocketError.WouldBlock ||
    			    ex.ErrorCode == (int) SocketError.IOPending ||
    			    ex.ErrorCode == (int) SocketError.NoBufferSpaceAvailable)
    			{
    				// socket buffer is probably full, wait and try again
    				Thread.Sleep(30);
    			}
    			else
    				throw; // any serious error occurr
    		}
    	} while (sent < size);
    }
