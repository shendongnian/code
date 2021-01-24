    protected void DataReceived(IAsyncResult result)
    {
    	var state = (StateObject) result.AsyncState;
    
    	// End the data receiving that the socket has done and get the number of bytes read.
    	var bytesCount = 0;
    
    	try
    	{
    		SocketError errorCode;
    		bytesCount = state.Socket.EndReceive(result, out errorCode);
    		if (errorCode != SocketError.Success)
    		{
    			bytesCount = 0;
    		}
    	}
    	catch (Exception ex)
    	{
    		this.RaiseOnErrorToClient(new Exception(nameof(this.DataReceived)));
    		this.RaiseOnErrorToClient(ex);
    	}
    
    	if (bytesCount > 0)
    	{
    		// Convert the data we have to a string.
    		this.DataBuffer += Encoding.UTF8.GetString(state.Buffer, 0, bytesCount);
    
    		// Record last time data received
    		this.LastDataReceivedOn = DateTime.UtcNow;
    		this.RaiseOnDataReceivedToClient(this.DataBuffer);
    
    		this.DataBuffer = string.Empty;
    		this.EstablishReceiver();
    	}
    }
