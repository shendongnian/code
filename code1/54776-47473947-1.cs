    public string GetMacAddress()
    {
    	const int MIN_MAC_ADDR_LENGTH = 12;
    	string macAddress = string.Empty;
    	Dictionary<string, long> macPlusSpeed = new Dictionary<string, long>();
    	try
    	{
    		foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
    		{
    			System.Diagnostics.Debug.WriteLine("Found MAC Address: " + nic.GetPhysicalAddress() + " Type: " + nic.NetworkInterfaceType);
    
    			string tempMac = nic.GetPhysicalAddress().ToString();
    
    			if(!string.IsNullOrEmpty(tempMac) && tempMac.Length >= MIN_MAC_ADDR_LENGTH)
    				macPlusSpeed.Add(tempMac, nic.Speed);
    		}
    
    		macAddress = macPlusSpeed.OrderByDescending(row => row.Value).ThenBy(row => row.Key).FirstOrDefault().Key;
    	}
    	catch{}
    
    	System.Diagnostics.Debug.WriteLine("Fastest MAC address: " + macAddress);
    
    	return macAddress;
    }
