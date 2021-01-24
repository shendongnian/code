	public event EventHandler<CallReceivedEventArgs> CallReceived;
	protected void OnCallReceived(EventArgs e)
	{
		var handler = CallReceived;
		if (handler != null)
			handler(this, e);
        
        // Note: For C# 6.0 and later, above statements can be simplified to
        // CallReceived?.Invoke(this, e);
	}
