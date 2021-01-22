	public static void ShowNetworkInterfaces()
	{
		// IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
		NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
		if (nics == null || nics.Length < 1)
		{
			Console.WriteLine("  No network interfaces found.");
			return;
		}
		Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
		foreach (NetworkInterface adapter in nics)
		{
			IPInterfaceProperties properties = adapter.GetIPProperties();
			Console.WriteLine();
			Console.WriteLine(adapter.Description);
			Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length,'='));
			Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
			Console.WriteLine("  Physical Address ........................ : {0}", adapter.GetPhysicalAddress().ToString());
			string versions ="";
	
			// Create a display string for the supported IP versions.
			if (adapter.Supports(NetworkInterfaceComponent.IPv4))
			{
				versions = "IPv4";
			}
			if (adapter.Supports(NetworkInterfaceComponent.IPv6))
			{
				if (versions.Length > 0)
				{
					versions += " ";
				}
				versions += "IPv6";
			}
			Console.WriteLine("  IP version .............................. : {0}", versions);
			UnicastIPAddressInformationCollection uniCast = properties.UnicastAddresses;
			if (uniCast != null)
			{
				foreach (UnicastIPAddressInformation uni in uniCast)
				{
					Console.WriteLine("  Unicast Address ......................... : {0}", uni.Address);
					Console.WriteLine("     Subnet Mask  ......................... : {0}", uni.IPv4Mask);
				}
			}
		Console.WriteLine();
		}
	}
