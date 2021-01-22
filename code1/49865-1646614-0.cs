    /// <summary>
    /// Converts an IP address to its UInt64[2] equivalent.
    /// For an IPv4 address, the first element will be 0,
    /// and the second will be a UInt32 representation of the four bytes.
    /// For an IPv6 address, the first element will be a UInt64
    /// representation of the first eight bytes, and the second will be the
    /// last eight bytes.
    /// </summary>
    /// <param name="ipAddress">The IP address to convert.</param>
    /// <returns></returns>
    private static ulong[] ConvertIPAddressToUInt64Array(string ipAddress)
    {
        byte[] addrBytes = System.Net.IPAddress.Parse(ipAddress).GetAddressBytes();
        if (System.BitConverter.IsLittleEndian)
        {
            //little-endian machines store multi-byte integers with the
            //least significant byte first. this is a problem, as integer
            //values are sent over the network in big-endian mode. reversing
            //the order of the bytes is a quick way to get the BitConverter
            //methods to convert the byte arrays in big-endian mode.
            System.Collections.Generic.List<byte> byteList = new System.Collections.Generic.List<byte>(addrBytes);
            byteList.Reverse();
            addrBytes = byteList.ToArray();
        }
        ulong[] addrWords = new ulong[2];
        if (addrBytes.Length > 8)
        {
            addrWords[0] = System.BitConverter.ToUInt64(addrBytes, 8);
            addrWords[1] = System.BitConverter.ToUInt64(addrBytes, 0);
        }
        else
        {
            addrWords[0] = 0;
            addrWords[1] = System.BitConverter.ToUInt32(addrBytes, 0);
        }
        return addrWords;
    }
