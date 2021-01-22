     public static PhysicalAddress GetBTMacAddress()  {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces()) {
            // Only consider Bluetooth network interfaces
            if (nic.NetworkInterfaceType != NetworkInterfaceType.FastEthernetFx && 
                nic.NetworkInterfaceType != NetworkInterfaceType.Wireless80211)){
                
                return nic.GetPhysicalAddress();
            }
 
        }
        return null;
    }
