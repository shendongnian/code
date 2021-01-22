    public static class IPAddressExtensions
    {
        // Collection of private CIDRs (IpAddress/Mask) 
    	private static Tuple<int, int>[] _privateCidrs = new []{"10.0.0.0/8", "172.16.0.0/12", "192.168.0.0/16"}
    		.Select(c=>Tuple.Create(BitConverter.ToInt32(IPAddress
                                        .Parse(c.Split('/')[0]).GetAddressBytes(), 0)
                                  , IPAddress.HostToNetworkOrder(-1 << (32-int.Parse(c.Split('/')[1])))))
            .ToArray();
    	public static bool IsPrivate(this IPAddress ipAddress)
    	{
    		int ip = BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0);
    		return _privateCidrs.Any(cidr=>(ip & cidr.Item2)==(cidr.Item1 & cidr.Item2));    		
    	}
    }
