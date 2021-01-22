    static IPAddress getInternetIPAddress()
    {
        try
        {
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress gateway = IPAddress.Parse(getInternetGateway());
            return findMatch(addresses, gateway);
        }
        catch (FormatException e) { return null; }
    }
    static string getInternetGateway()
    {
        using (Process tracert = new Process())
        {
            ProcessStartInfo startInfo = tracert.StartInfo;
            startInfo.FileName = "tracert.exe";
            startInfo.Arguments = "-h 1 208.77.188.166"; // www.example.com
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            tracert.Start();
            using (StreamReader reader = tracert.StandardOutput)
            {
                string line = "";
                for (int i = 0; i < 9; ++i)
                    line = reader.ReadLine();
                line = line.Trim();
                return line.Substring(line.LastIndexOf(' ') + 1);
            }
        }
    }
    static IPAddress findMatch(IPAddress[] addresses, IPAddress gateway)
    {
        byte[] gatewayBytes = gateway.GetAddressBytes();
        foreach (IPAddress ip in addresses)
        {
            byte[] ipBytes = ip.GetAddressBytes();
            if (ipBytes[0] == gatewayBytes[0]
                && ipBytes[1] == gatewayBytes[1]
                && ipBytes[2] == gatewayBytes[2])
            {
                return ip;
            }
        }
        return null;
    }
