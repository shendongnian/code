    NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
    foreach (NetworkInterface networkInterface in networkInterfaces)
    {
        if (networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
        {
            IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
            
            var gateways = ipProperties.GatewayAddresses.Select(ga => ga.Address);
            var dns = ipProperties.DnsAddresses;
            
            if (dns.Any(d => gateways.Contains(d))){
                Console.Write("dns router found on interface " + networkInterface.Name);
            }
        }
    }
