    using System;
    using System.Net;
    using System.Net.NetworkInformation;
    //...
    public static string GetFQDN()
    {
        string domainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;
        string hostName = Dns.GetHostName();
        if(!hostName.EndsWith(domainName))  // if hostname does not already include domain name
        {
            hostName += "." + domainName;   // add the domain name part
        }
        return hostName;                    // return the fully qualified name
    }
