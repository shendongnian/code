	NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
	foreach(NetworkInterface  adapter in  nics)
	{
		foreach(var x in adapter.GetIPProperties().UnicastAddresses)
		{
			if (x.Address.AddressFamily == AddressFamily.InterNetwork  && x.IsDnsEligible)
			{
						Console.WriteLine(" IPAddress ........ : {0:x}", x.Address.ToString());
			}
		}
	}
