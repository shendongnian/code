    public static IPAddress[] GetAddresses(string rangeString)
    {
        var match = Regex.Match(rangeString, @"(?<ip1>\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3})-(?<ip2>\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3})");
        if (!match.Success || !IPAddress.TryParse(match.Groups["ip1"].Value, out IPAddress ip1) || !IPAddress.TryParse(match.Groups["ip2"].Value, out IPAddress ip2))
        {
            throw new ArgumentException("Range invalid.");
        }
        return GetAddresses(ip1, ip2);
    }
    public static IPAddress[] GetAddresses(IPAddress startAddress, IPAddress endAddress)
    {
        var startNumber = IPToNumber(startAddress);
        var endNumber = IPToNumber(endAddress);
        var addresses = new List<IPAddress>();
        for (uint i = startNumber; i <= endNumber; ++i)
        {
            addresses.Add(NumberToIP(i));
        }
        return addresses.ToArray();
    }
    private static UInt32 IPToNumber(IPAddress ip)
    {
        var bytes = ip.GetAddressBytes();
        UInt32 result = 0;
        for (int i = 0; i < bytes.Length; ++i)
        {
            result *= 255;
            result += bytes[i];
        }
        return result;
    }
    private static IPAddress NumberToIP(UInt32 number)
    {
        var bytes = new Stack<byte>(4);
        while (number > 0)
        {
            bytes.Push((byte)(number % 255));
            number /= 255;
        }
        return new IPAddress(bytes.ToArray());
    }
