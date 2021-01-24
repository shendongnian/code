	private bool IsIpAddressAllowed(string IpAddress)
	{
		MessageProperties prop = context.IncomingMessageProperties;
		RemoteEndpointMessageProperty endpoint =
			prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
		String ipAddress = endpoint.Address; // Here I get the IP
		WinEventLog.EventLog.logInfo(null, "Connection from : " + ipAddress);
		
		return MyTestOnIP(ipAddress);
	}
