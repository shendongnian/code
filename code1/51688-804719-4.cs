    using System;
    using System.Net;
    //...
    public static string GetFQDN()
    {
        string domainName = NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        string hostName = Dns.GetHostName();
        if(!hostName.Contains(domainName))            // if the hostname does not already include the domain name
        {
            hostName = hostName + "." + domainName;   // add the domain name part
        }
        return hostName;                              // return the fully qualified domain name
    }
