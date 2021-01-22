    var Options = new JHSoftware.DnsClient.RequestOptions();
    Options.DnsServers = new System.Net.IPAddress[] { 
               System.Net.IPAddress.Parse("1.1.1.1"), 
               System.Net.IPAddress.Parse("2.2.2.2") };
    var IPs = JHSoftware.DnsClient.LookupHost("www.simpledns.com", 
                                              JHSoftware.DnsClient.IPVersion.IPv4, 
                                              Options);
    foreach(var IP in IPs)
    {
       Console.WriteLine(IP.ToString());
    }
