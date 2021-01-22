    IPAddress ip = new IPAddress(new byte[] { 192, 168, 0, 1 });
    int bits = 25;
    
    uint mask = ~(uint.MaxValue >> bits);
    
    // Convert the IP address to bytes.
    byte[] ipBytes = ip.GetAddressBytes();
    // BitConverter gives bytes in opposite order to GetAddressBytes().
    byte[] maskBytes = BitConverter.GetBytes(mask).Reverse().ToArray();
    
    byte[] startIPBytes = new byte[ipBytes.Length];
    byte[] endIPBytes = new byte[ipBytes.Length];
    
    // Calculate the bytes of the start and end IP addresses.
    for (int i = 0; i < ipBytes.Length; i++)
    {
        startIPBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
        endIPBytes[i] = (byte)(ipBytes[i] | ~maskBytes[i]);
    }
    
    // Convert the bytes to IP addresses.
    IPAddress startIP = new IPAddress(startIPBytes);
    IPAddress endIP = new IPAddress(endIPBytes);
