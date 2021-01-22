    private string FetchIP()
    {
        //Get all IP registered
        List<string> IPList = new List<string>();
        IPHostEntry host;
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                IPList.Add(ip.ToString());
            }
        }
        //Find the first IP which is not only local
        foreach (string a in IPList)
        {
            Ping p = new Ping();
            string[] b = a.Split('.');
            string ip2 = b[0] + "." + b[1] + "." + b[2] + ".1";
            PingReply t = p.Send(ip2);
            p.Dispose();
            if (t.Status == IPStatus.Success && ip2 != a)
            {
                return a;
            }
        }
        return null;
    }
