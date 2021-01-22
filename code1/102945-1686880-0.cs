    static void Main(string[] args)
    {
        WlanClient client = new WlanClient();
        foreach ( WlanClient.WlanInterface wlanIface in client.Interfaces )
        {
            Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList( 0 );
            foreach ( Wlan.WlanAvailableNetwork network in networks )
            {
                Console.WriteLine( "Found network with SSID {0} and Siqnal Quality {1}.", GetStringForSSID(network.dot11Ssid), network.wlanSignalQuality);
            }
        }
    }
    static string GetStringForSSID(Wlan.Dot11Ssid ssid)
    {
        return Encoding.ASCII.GetString(ssid.SSID, 0, (int) ssid.SSIDLength);
    }
