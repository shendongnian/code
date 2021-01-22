    /// <summary>
    /// Finds the MAC address of the NIC with maximum speed.
    /// </summary>
    /// <returns>The MAC address.</returns>
    private string GetMacAddress()
    {
        const int MIN_MAC_ADDR_LENGTH = 12;
        string macAddress = string.Empty;
        long maxSpeed = -1;
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            log.Debug(
                "Found MAC Address: " + nic.GetPhysicalAddress() +
                " Type: " + nic.NetworkInterfaceType);
            string tempMac = nic.GetPhysicalAddress().ToString();
            if (nic.Speed > maxSpeed &&
                !string.IsNullOrEmpty(tempMac) &&
                tempMac.Length >= MIN_MAC_ADDR_LENGTH)
            {
                log.Debug("New Max Speed = " + nic.Speed + ", MAC: " + tempMac);
                maxSpeed = nic.Speed;
                macAddress = tempMac;
            }
        }
        
        return macAddress;
    }
