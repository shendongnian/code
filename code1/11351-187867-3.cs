    var wlanClient = new WlanClient();
    foreach (WlanClient.WlanInterface wlanInterface in wlanClient.Interfaces)
    {
        Wlan.WlanBssEntry[] wlanBssEntries = wlanInterface.GetNetworkBssList();
        foreach (Wlan.WlanBssEntry wlanBssEntry in wlanBssEntries)
        {
            byte[] macAddr = wlanBssEntry.dot11Bssid;
            var macAddrLen = (uint) macAddr.Length;
            var str = new string[(int) macAddrLen];
            for (int i = 0; i < macAddrLen; i++)
            {
                str[i] = macAddr[i].ToString("x2");
            }
            string mac = string.Join("", str);
            Console.WriteLine(mac);
        }
    }
