    public static string GetLocalIPAddress()
    {
        var isConnected = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        if(isConnected){
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
