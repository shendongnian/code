    private void EstablishReceiver()
    {
    	try
    	{
    		var state = new StateObject(client.Client);
    		// Set up again to get the next chunk of data.
    		this.client.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, this.DataReceived, state);
    	}
    	catch (Exception ex)
    	{
    		this.RaiseOnErrorToClient(new Exception(nameof(this.EstablishReceiver)));
    		this.RaiseOnErrorToClient(ex);
    	}
    }
