	public static class IpAddresses
	{
		public static Tuple<IPAddress, IPAddress> GetSubnetAndMaskFromCidr(string cidr)
		{
			var delimiterIndex = cidr.IndexOf('/');
			string ipSubnet = cidr.Substring(0, delimiterIndex);
			string mask = cidr.Substring(delimiterIndex + 1);
			
			var subnetAddress = IPAddress.Parse(ipSubnet);
			if (subnetAddress.AddressFamily == AddressFamily.InterNetworkV6)
			{
				// ipv6
				var ip = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", NumberStyles.HexNumber) << (128 - int.Parse(mask));
				var maskBytes = new[]
				{
					(byte)((ip & BigInteger.Parse("00FF000000000000000000000000000000", NumberStyles.HexNumber)) >> 120),
					(byte)((ip & BigInteger.Parse("0000FF0000000000000000000000000000", NumberStyles.HexNumber)) >> 112),
					(byte)((ip & BigInteger.Parse("000000FF00000000000000000000000000", NumberStyles.HexNumber)) >> 104),
					(byte)((ip & BigInteger.Parse("00000000FF000000000000000000000000", NumberStyles.HexNumber)) >> 96),
					(byte)((ip & BigInteger.Parse("0000000000FF0000000000000000000000", NumberStyles.HexNumber)) >> 88),
					(byte)((ip & BigInteger.Parse("000000000000FF00000000000000000000", NumberStyles.HexNumber)) >> 80),
					(byte)((ip & BigInteger.Parse("00000000000000FF000000000000000000", NumberStyles.HexNumber)) >> 72),
					(byte)((ip & BigInteger.Parse("0000000000000000FF0000000000000000", NumberStyles.HexNumber)) >> 64),
					(byte)((ip & BigInteger.Parse("000000000000000000FF00000000000000", NumberStyles.HexNumber)) >> 56),
					(byte)((ip & BigInteger.Parse("00000000000000000000FF000000000000", NumberStyles.HexNumber)) >> 48),
					(byte)((ip & BigInteger.Parse("0000000000000000000000FF0000000000", NumberStyles.HexNumber)) >> 40),
					(byte)((ip & BigInteger.Parse("000000000000000000000000FF00000000", NumberStyles.HexNumber)) >> 32),
					(byte)((ip & BigInteger.Parse("00000000000000000000000000FF000000", NumberStyles.HexNumber)) >> 24),
					(byte)((ip & BigInteger.Parse("0000000000000000000000000000FF0000", NumberStyles.HexNumber)) >> 16),
					(byte)((ip & BigInteger.Parse("000000000000000000000000000000FF00", NumberStyles.HexNumber)) >> 8),
					(byte)((ip & BigInteger.Parse("00000000000000000000000000000000FF", NumberStyles.HexNumber)) >> 0),
				};
				return Tuple.Create(subnetAddress, new IPAddress(maskBytes));
			}
			else
			{
				// ipv4
				uint ip = 0xFFFFFFFF << (32 - int.Parse(mask));
				var maskBytes = new[]
				{
					(byte)((ip & 0xFF000000) >> 24),
					(byte)((ip & 0x00FF0000) >> 16),
					(byte)((ip & 0x0000FF00) >> 8),
					(byte)((ip & 0x000000FF) >> 0),
				};
				return Tuple.Create(subnetAddress, new IPAddress(maskBytes));
			}
		}
		public static bool IsAddressOnSubnet(IPAddress address, IPAddress subnet, IPAddress mask)
		{
			byte[] addressOctets = address.GetAddressBytes();
			byte[] subnetOctets = mask.GetAddressBytes();
			byte[] networkOctets = subnet.GetAddressBytes();
			
			// ensure that IPv4 isn't mixed with IPv6
			if (addressOctets.Length != subnetOctets.Length
				|| addressOctets.Length != networkOctets.Length)
			{
				return false;
			}
			for (int i = 0; i < addressOctets.Length; i += 1)
			{
				var addressOctet = addressOctets[i];
				var subnetOctet = subnetOctets[i];
				var networkOctet = networkOctets[i];
				if (networkOctet != (addressOctet & subnetOctet))
				{
					return false;
				}
			}
			return true;
		}
	}
