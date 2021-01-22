	public static uint ConvertFromIpAddressToInteger(string ipAddress)
	{
		var address = IPAddress.Parse(ipAddress);
		byte[] bytes = address.GetAddressBytes();
		// flip big-endian(network order) to little-endian
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
		}
		return BitConverter.ToUInt32(bytes, 0);
	}
	
	public static string ConvertFromIntegerToIpAddress(uint ipAddress)
	{
		byte[] bytes = BitConverter.GetBytes(ipAddress);
		// flip little-endian to big-endian(network order)
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
		}
		return new IPAddress(bytes).ToString();
	}
