    // will likely return MAC of loopback interface. mac is not useful in most applications.
    public string GetMacAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        String macAddress = String.Empty; // use the same string object please, capital S in both cases.
        foreach (NetworkInterface adapter in nics)
        {
            // IPInterfaceProperties properties = adapter.GetIPProperties(); // not needed
            macAddress = adapter.GetPhysicalAddress().ToString();
            if (macAddress != String.Empty)  
            {
                return macAddress; // prematurely exit loop. note this only returns the mac of the first interface it finds.
            }
        }
        return String.Empty;
    }
