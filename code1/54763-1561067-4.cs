    /// <summary>
    /// Finds the MAC address of the first operation NIC found.
    /// </summary>
    /// <returns>The MAC address.</returns>
    private string GetMacAddress()
    {
        string macAddresses = string.Empty;
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.OperationalStatus == OperationalStatus.Up)
            {
                macAddresses += nic.GetPhysicalAddress().ToString();
                break;
            }
        }
        
        return macAddresses;
    }
