    static IPAddress FindLanAddress()
    {
        IPAddress gateway = FindGetGatewayAddress();
        if (gateway == null)
            return null;
    
        IPAddress[] pIPAddress = Dns.GetHostAddresses(Dns.GetHostName());
         
        foreach (IPAddress address in pIPAddress)            {
            if (IsAddressOfGateway(address, gateway))
                    return address;
        return null;
    }
    static bool IsAddressOfGateway(IPAddress address, IPAddress gateway)
    {
        if (address != null && gateway != null)
            return IsAddressOfGateway(address.GetAddressBytes(),gateway.GetAddressBytes());
        return false;
    }
    static bool IsAddressOfGateway(byte[] address, byte[] gateway)
    {
        if (address != null && gateway != null)
        {
            int gwLen = gateway.Length;
            if (gwLen > 0)
            {
                if (address.Length == gateway.Length)
                {
                    --gwLen;
                    int counter = 0;
                    for (int i = 0; i < gwLen; i++)
                    {
                        if (address[i] == gateway[i])
                            ++counter;
                    }
                    return (counter == gwLen);
                }
            }
        }
        return false;
    }
    static IPAddress FindGetGatewayAddress()
    {
        IPGlobalProperties ipGlobProps = IPGlobalProperties.GetIPGlobalProperties();
        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            IPInterfaceProperties ipInfProps = ni.GetIPProperties();
            foreach (GatewayIPAddressInformation gi in ipInfProps.GatewayAddresses)
                return gi.Address;
        }
        return null;
    }
    
