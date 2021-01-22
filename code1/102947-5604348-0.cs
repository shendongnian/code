    class Program
    {
        static void Main(string[] args)
        {
            WlanClient client = new WlanClient();
            // Wlan = new WlanClient();
            try
            {
                foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
                {
                    Wlan.WlanBssEntry[] wlanBssEntries = wlanIface.GetNetworkBssList();
                    foreach (Wlan.WlanBssEntry network in wlanBssEntries)
                    {
                        int rss = network.rssi;
                        //     MessageBox.Show(rss.ToString());
                        byte[] macAddr = network.dot11Bssid;
                        string tMac = "";
                        for (int i = 0; i < macAddr.Length; i++)
                        {
                            tMac += macAddr[i].ToString("x2").PadLeft(2, '0').ToUpper();
                        }
                        Console.WriteLine("Found network with SSID {0}.", System.Text.ASCIIEncoding.ASCII.GetString(network.dot11Ssid.SSID).ToString());
                        Console.WriteLine("Signal: {0}%.", network.linkQuality);
                        Console.WriteLine("BSS Type: {0}.", network.dot11BssType);
                        Console.WriteLine("MAC: {0}.", tMac);
                        Console.WriteLine("RSSID:{0}", rss.ToString());
                  
                    }
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        }
    
