    socket.Blocking = false;
    const int ChunkSize = 1492;
    const int ReceiveTimeout = 10000;
    const int SendTimeout = 10000;
    
    public void Send(Byte[] data)
    {
    	var sizeBytes = BitConverter.GetBytes(data.Length);
    	SendInternal(sizeBytes);
    	SendInternal(data);
    }
    
    public Byte[] Receive()
    {
    	var sizeBytes = ReceiveInternal(4);
    	var size = BitConverter.ToInt32(sizeBytes, 0);
    	var data = ReceiveInternal(size);
        return data;
    }
    
    private void SendInternal(Byte[] data)
    {
    	var error = SocketError.Success;
    	var lastUpdate = Environment.TickCount;
    	var size = data.Length;
    	var count = 0;
    	var sent = 0;
    
    	while (sent < size)
    	{
    		count = Math.Min(ChunkSize, size - sent);
    		count = socket.Send(data, sent, count, SocketFlags.None, out error);
    
    		if (count > 0)
    		{
    			sent += count;
    			lastUpdate = Environment.TickCount;
    		}
    
    		if (error != SocketError.InProgress && error != SocketError.Success && error != SocketError.WouldBlock)
    			throw new SocketException((Int32)error);
    		if (Environment.TickCount - lastUpdate > SendTimeout)
    			throw new TimeoutException("Send operation timed out.");
    		if (count == 0 && !socket.Poll(100, SelectMode.SelectWrite))
    			throw new SocketException((Int32)SocketError.Shutdown);
    	}
    }
    
    private Byte[] ReceiveInternal(Int32 size)
    {
    	var error = SocketError.Success;
    	var lastUpdate = Environment.TickCount;
    	var buffer = new Byte[ChunkSize];
    	var count = 0;
    	var received = 0;
    
    	using (var ms = new MemoryStream(size))
    	{
    		while (received < size)
    		{
    			count = Math.Min(ChunkSize, size - received);
    			count = socket.Receive(buffer, 0, count, SocketFlags.None, out error);
    
    			if (count > 0)
    			{
    				ms.Write(buffer, 0, count);
    				received += count;
    				lastUpdate = Environment.TickCount;
    			}
    
    			if (error != SocketError.InProgress && error != SocketError.Success && error != SocketError.WouldBlock)
    				throw new SocketException((Int32)error);
    			if (Environment.TickCount - lastUpdate > ReceiveTimeout)
    				throw new TimeoutException("Receive operation timed out.");
    			if (count == 0 && socket.Poll(100, SelectMode.SelectRead) && socket.Available == 0)
    				throw new SocketException((Int32)SocketError.Shutdown);
    		}
    
    		return ms.ToArray();
    	}
    }
