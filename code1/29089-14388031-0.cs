    public uint GetIpAsUInt32(string ipString)
    {
        IPAddress address = IPAddress.Parse(ipString);
        byte[] ipBytes = address.GetAddressBytes();
        Array.Reverse(ipBytes);
        return BitConverter.ToUInt32(ipBytes, 0);
    }
    public string GetIpAsString(uint ipVal)
    {
        byte[] ipBytes = BitConverter.GetBytes(ipVal);
        Array.Reverse(ipBytes);
        return new IPAddress(ipBytes).ToString();
    }
