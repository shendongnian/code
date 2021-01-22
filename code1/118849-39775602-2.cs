    using System.Net;
    using System.Net.Sockets;
    using System.Net.NetworkInformation;
    using System.Diagnostics;
	internal static bool ConnectedToInternet()
	{
		const int maxHops = 30;
		const string someFarAwayIpAddress = "8.8.8.8";
		// Keep pinging further along the line from here to google 
		// until we find a response that is from a routable address
		for (int ttl = 1; ttl <= maxHops; ttl++)
		{
			Ping pinger = new Ping();
			PingOptions options = new PingOptions(ttl, true);
			byte[] buffer = new byte[32];
			PingReply reply = null;
			try
			{
			 	reply = pinger.Send(someFarAwayIpAddress, 10000, buffer, options);
			}
			catch (System.Net.NetworkInformation.PingException pingex)
			{
				Debug.Print("Ping exception (probably due to no network connection or recent change in network conditions), hence not connected to internet. Message: " + pingex.Message);
				return false;
			}
			System.Diagnostics.Debug.Print("Hop #" + ttl.ToString() + " is " + (reply.Address == null ? "null" : reply.Address.ToString()) + ", " + reply.Status.ToString());
			if (reply.Status != IPStatus.TtlExpired && reply.Status != IPStatus.Success)
			{
				Debug.Print("Hop #" + ttl.ToString() + " is " + reply.Status.ToString() + ", hence we are not connected.");
				return false;
			}
			if (IsRoutableAddress(reply.Address))
			{
				System.Diagnostics.Debug.Print("That's routable so you must be connected to the internet.");
				return true;
			}
		}
		return false;
	}
	private static bool IsRoutableAddress(IPAddress addr)
	{
		if (addr == null)
		{
			return false;
		}
		else if (addr.AddressFamily == AddressFamily.InterNetworkV6)
		{
			return !addr.IsIPv6LinkLocal && !addr.IsIPv6SiteLocal;
		}
		else // IPv4
		{
			byte[] bytes = addr.GetAddressBytes();
			if (bytes[0] == 10)
			{	// Class A network
				return false;
			}
			else if (bytes[0] == 172 && bytes[1] >= 16 && bytes[1] <= 31)
			{	// Class B network
				return false;
			}
			else if (bytes[0] == 192 && bytes[1] == 168)
			{	// Class C network
				return false;
			}
			else
			{	// None of the above, so must be routable
				return true;
			}
		}
	}
