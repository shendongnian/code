    public static string GetFQDN()
    {
        string domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        string hostName = System.Net.Dns.GetHostName();
        string fqdn = "";
        if (!hostName.Contains(domainName))
            fqdn = hostName + "." + domainName;
        else
            fqdn = hostName;
        return fqdn;
    }
