    string GetMacAddress()
    {
    	var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
    	if (connectionProfile == null) return "";
    
    	var inUseId = connectionProfile.NetworkAdapter.NetworkAdapterId.ToString("B").ToUpperInvariant();
    	if(string.IsNullOrWhiteSpace(inUseId)) return "";
    
	    var mac = NetworkInterface.GetAllNetworkInterfaces()
            .Where(n => inUseId == n.Id)
			.Select(n => n.GetPhysicalAddress().GetAddressBytes().Select(b=>b.ToString("X2")))
			.Select(macBytes => string.Join(" ", macBytes))
			.FirstOrDefault();
    
    	return mac;
    }
