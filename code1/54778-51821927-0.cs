    public string GetDefaultMacAddress()
    {
    	Dictionary<string, long> macAddresses = new Dictionary<string, long>();
    	foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
    	{
    		if (nic.OperationalStatus == OperationalStatus.Up)
    			macAddresses[nic.GetPhysicalAddress().ToString()] = nic.GetIPStatistics().BytesSent + nic.GetIPStatistics().BytesReceived;
    	}
    	long maxValue = 0;
    	string mac = "";
    	foreach(KeyValuePair<string, long> pair in macAddresses)
    	{
    		if (pair.Value > maxValue)
    		{
    			mac = pair.Key;
    			maxValue = pair.Value;
    		}
    	}
    	return mac;
    }
