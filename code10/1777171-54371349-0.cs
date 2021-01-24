public static class IPManager
{
    public enum ADDRESSFAM
    {
        IPv4, IPv6
    }
    public static string GetIP(ADDRESSFAM Addfam)
    {
      string ret = "";
      List<string> IPs = GetAllIPs(Addfam, false);
      if (IPs.Count > 0) {
        ret = IPs[IPs.Count - 1];
      }
      return ret;
    }
    
    public static List<string> GetAllIPs(ADDRESSFAM Addfam, bool includeDetails)
    {
        //Return null if ADDRESSFAM is Ipv6 but Os does not support it
        if (Addfam == ADDRESSFAM.IPv6 && !Socket.OSSupportsIPv6)
        {
            return null;
        }
        List<string> output = new List<string>();
        
        foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
        {
            
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS
            NetworkInterfaceType _type1 = NetworkInterfaceType.Wireless80211;
            NetworkInterfaceType _type2 = NetworkInterfaceType.Ethernet;
            
            bool isCandidate = (item.NetworkInterfaceType == _type1 || item.NetworkInterfaceType == _type2);
            
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            // as of MacOS (10.13) and iOS (12.1), OperationalStatus seems to be always "Unknown".
            isCandidate = isCandidate && item.OperationalStatus == OperationalStatus.Up;
#endif
            if (isCandidate)
#endif 
            {
                foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                {
                    //IPv4
                    if (Addfam == ADDRESSFAM.IPv4)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            string s = ip.Address.ToString();
                            if (includeDetails) {
                                s += "  " + item.Description.PadLeft(6) + item.NetworkInterfaceType.ToString().PadLeft(10);
                            }
                            output.Add(s);
                        }
                    }
                    //IPv6
                    else if (Addfam == ADDRESSFAM.IPv6)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            output.Add(ip.Address.ToString());
                        }
                    }
                }
            }
        }
        return output;
    }
}
  [1]: https://stackoverflow.com/a/51977237/230851
