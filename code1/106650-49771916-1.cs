    public static string GetFQDN()
    {
        string domainName = NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        string hostName = Dns.GetHostName();
        string fqdn = “”;
        if (!hostName.Contains(domainName))
            fqdn = hostName + “.” +domainName;
        else
            fqdn = hostName;
    
        return fqdn;
    }
