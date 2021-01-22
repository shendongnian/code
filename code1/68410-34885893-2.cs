	// ************************************************************************
	/// <summary>
	/// Will search for the an active NetworkInterafce that has a Gateway, otherwise
	/// it will fallback to try from the DNS which is not safe.
	/// </summary>
	/// <returns></returns>
	public static NetworkInterface GetMainNetworkInterface()
	{
		List<NetworkInterface> candidates = new List<NetworkInterface>();
		if (NetworkInterface.GetIsNetworkAvailable())
		{
			NetworkInterface[] NetworkInterfaces =
				NetworkInterface.GetAllNetworkInterfaces();
			foreach (
				NetworkInterface ni in NetworkInterfaces)
			{
				if (ni.OperationalStatus == OperationalStatus.Up)
					candidates.Add(ni);
			}
		}
		if (candidates.Count == 1)
		{
			return candidates[0];
		}
		// Accoring to our tech, the main NetworkInterface should have a Gateway 
		// and it should be the ony one with a gateway.
		if (candidates.Count > 1)
		{
			for (int n = candidates.Count - 1; n >= 0; n--)
			{
				if (candidates[n].GetIPProperties().GatewayAddresses.Count == 0)
				{
					candidates.RemoveAt(n);
				}
			}
			if (candidates.Count == 1)
			{
				return candidates[0];
			}
		}
		// Fallback to try by getting my ipAdress from the dns
		IPAddress myMainIpAdress = null;
		IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
		foreach (IPAddress ip in host.AddressList)
		{
			if (ip.AddressFamily == AddressFamily.InterNetwork) // Get the first IpV4
			{
				myMainIpAdress = ip;
				break;
			}
		}
		if (myMainIpAdress != null)
		{
			NetworkInterface[] NetworkInterfaces =
				NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface ni in NetworkInterfaces)
			{
				if (ni.OperationalStatus == OperationalStatus.Up)
				{
					IPInterfaceProperties props = ni.GetIPProperties();
					foreach (UnicastIPAddressInformation ai in props.UnicastAddresses)
					{
						if (ai.Address.Equals(myMainIpAdress))
						{
							return ni;
						}
					}
				}
			}
		}
		return null;
	}
	// ******************************************************************
	/// <summary>
	/// AddressFamily.InterNetwork = IPv4
	/// Thanks to Dr. Wilys Apprentice at
	/// http://stackoverflow.com/questions/1069103/how-to-get-the-ip-address-of-the-server-on-which-my-c-sharp-application-is-runni
	/// using System.Net.NetworkInformation;
	/// </summary>
	/// <param name="mac"></param>
	/// <param name="addressFamily">AddressFamily.InterNetwork = IPv4,  AddressFamily.InterNetworkV6 = IPv6</param>
	/// <returns></returns>
	public static IPAddress GetIpFromMac(PhysicalAddress mac, AddressFamily addressFamily = AddressFamily.InterNetwork)
	{
		NetworkInterface[] NetworkInterfaces =
			NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface ni in NetworkInterfaces)
		{
			if (ni.GetPhysicalAddress().Equals(mac))
			{
				if (ni.OperationalStatus == OperationalStatus.Up)
				{
					IPInterfaceProperties props = ni.GetIPProperties();
					foreach (UnicastIPAddressInformation ai in props.UnicastAddresses)
					{
						if (ai.DuplicateAddressDetectionState == DuplicateAddressDetectionState.Preferred)
						{
							if (ai.Address.AddressFamily == addressFamily)
							{
								return ai.Address;
							}
						}
					}
				}
			}
		}
		return null;
	}
	// ******************************************************************
	/// <summary>
	/// Return the best guess of main ipAdress. To get it in the form aaa.bbb.ccc.ddd just call 
	/// '?.ToString() ?? ""' on the result.
	/// </summary>
	/// <returns></returns>
	public static IPAddress GetMyInternetIpAddress()
	{
		NetworkInterface ni = GetMainNetworkInterface();
		IPAddress ipAddress = GetIpFromMac(ni.GetPhysicalAddress());
		if (ipAddress == null) // could it be possible ?
		{
			ipAddress = GetIpFromMac(ni.GetPhysicalAddress(), AddressFamily.InterNetworkV6);
		}
		return ipAddress;
	}
	// ******************************************************************
