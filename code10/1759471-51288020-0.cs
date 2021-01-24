    async Task RegisterServiceAsync()
    {
        var hostNames = NetworkInformation
            .GetHostNames()
            .Where(x => x.Type == HostNameType.DomainName)
            .Select(x => new KeyValuePair<string, HostName>(x.ToString(), x))
            .ToList();
        var hostName = Pick("Pick a host name:", hostNames);
        Console.WriteLine($"Host name is \"{hostName}\"");
        var service = new DnssdServiceInstance(
            dnssdServiceInstanceName: "instanceName._abcservice._tcp.local.",
            hostName: hostName,
            port: 13337
        );
        using (var socket = new StreamSocketListener())
        {
            var registration = await service.RegisterStreamSocketListenerAsync(socket);
            Console.WriteLine(registration.Status);
            Console.WriteLine($"Renamed: {registration.HasInstanceNameChanged}");
            Console.WriteLine($"Service instance name: {service.DnssdServiceInstanceName}");
            Console.ReadKey(true);
        }
    }
