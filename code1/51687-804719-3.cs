    using System;
    using System.Net;
    //...
    public static string GetFQDN()
    {
        string domainName = NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        string hostName = Dns.GetHostName();
        return hostName.Contains(domainName)
               ? hostName
               : string.Concat(hostName, ".", domainName);
    }
