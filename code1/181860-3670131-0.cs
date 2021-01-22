    using System.Net.NetworkInformation;
    List<NetworkInterface> Interfaces = new List<NetworkInterface>();
	foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
	{
		if (nic.OperationalStatus == OperationalStatus.Up)
		{
			Interfaces.Add(nic);
		}
	}
	NetworkInterface result = null;
	foreach (NetworkInterface nic in Interfaces)
	{
		if (result == null)
		{
			result = nic;
		}
		else
		{
			if (nic.GetIPProperties().GetIPv4Properties() != null)
			{
				if (nic.GetIPProperties().GetIPv4Properties().Index < result.GetIPProperties().GetIPv4Properties().Index)
					result = nic;
			}
		}
	}
	Console.WriteLine(result.Name);
