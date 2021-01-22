    public static long ConvertIPToLong(string ipAddress)
    {
        System.Net.IPAddress ip;
    
        if (System.Net.IPAddress.TryParse(ipAddress, out ip))
        {
            byte[] bytes = ip.GetAddressBytes();
    
            return (long)
                (
                16777216 * (long)bytes[0] +
                65536 * (long)bytes[1] +
                256 * (long)bytes[2] +
                (long)bytes[3]
                )
                ;
        }
        else
            return 0;
    }
