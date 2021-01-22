    public static IEnumerable<IPAddress> GetLocalIpAddresses()
    {
        // Get the list of network interfaces for the local computer.
        var adapters = NetworkInterface.GetAllNetworkInterfaces();
    
        // Return the list of local IPv4 addresses excluding the local
        // host and disconnected addresses.
        return (from adapter in adapters
                let properties = adapter.GetIPProperties()
                where adapter.OperationalStatus == OperationalStatus.Up &&
                      properties.UnicastAddresses.Count > 0 &&
                      properties.UnicastAddresses.First().Address.AddressFamily == AddressFamily.InterNetwork &&
                      !properties.UnicastAddresses.First().Address.Equals(IPAddress.Loopback)
                select properties.UnicastAddresses.First().Address).ToList();
    }
