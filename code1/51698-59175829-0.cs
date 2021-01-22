    private static string GetLocalhostFQDN()
    {
        var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
        return $"{ipProperties.HostName}.{ipProperties.DomainName}";
    }
