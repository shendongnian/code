    NetworkInterface[] nics=NetworkInterface.GetAllNetworkInterfaces();
    
    foreach (NetworkInterface adapter in nics)
    {
        if (adapter.OperationalStatus == OperationalStatus.Up)
        {
            if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
                Console.WriteLine("Wifi");
            }
        }
    }
