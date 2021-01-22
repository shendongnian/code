    public static string GetLocalhostFqdn()
    {
        var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
        return string.IsNullOrWhiteSpace(ipProperties.DomainName) ? ipProperties.HostName : string.Format("{0}.{1}", ipProperties.HostName, ipProperties.DomainName);
    }
