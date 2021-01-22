    static string getInternetGateway()
    {
        using (Process tracert = new Process())
        {
            ProcessStartInfo startInfo = tracert.StartInfo;
            startInfo.FileName = "tracert";
            startInfo.Arguments = "-h 1 www.google.com";
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
    static IPAddress findMatch(IPAddress[] ips, IPAddress gateway)
    {
        byte[] gatewayBytes = gateway.GetAddressBytes();
        foreach (var ip in ips)
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
