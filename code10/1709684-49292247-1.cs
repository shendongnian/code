    protected void DataReceived(IAsyncResult result)
    {
    	// End the data receiving that the socket has done and get the number of bytes read.
    	var bytesCount = 0;
    
    	if (result == currentAsyncResult)
    	{
    		try
    		{
    			bytesCount = this.client.Client.EndReceive(result);
    		}
    		catch (Exception ex)
    		{
    			this.RaiseOnErrorToClient(new Exception(nameof(this.DataReceived)));
    			this.RaiseOnErrorToClient(ex);
    		}
    	}
    
    	// No data received, establish receiver and return
    	if (bytesCount == 0)
    	{
    		this.EstablishReceiver();
    		return;
    	}
    
    	// Convert the data we have to a string.
    	this.DataBuffer += Encoding.UTF8.GetString(this.buffer, 0, bytesCount);
    
    	// Record last time data received
    	this.LastDataReceivedOn = DateTime.UtcNow;
    	this.RaiseOnDataReceivedToClient(this.DataBuffer);
    
    	this.DataBuffer = string.Empty;
    	this.EstablishReceiver();
    }
