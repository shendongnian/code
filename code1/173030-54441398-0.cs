    try
    {
        using (var ping = new Ping())
        {
            var pingResult = ping.Send("google.com");
            if (pingResult?.Status == IPStatus.Success)
            {
                pingResult = ping.Send(pingResult.Address, 3000, "ping".ToAsciiBytes(), new PingOptions { Ttl = 2 });
                var isRealIp = !Helpers.IsLocalIp(pingResult?.Address);
                Console.WriteLine(pingResult?.Address == null
                    ? $"Has {(isRealIp ? string.Empty : "no ")}real IP, status: {pingResult?.Status}"
                    : $"Has {(isRealIp ? string.Empty : "no ")}real IP, response from: {pingResult.Address}, status: {pingResult.Status}");
                Console.WriteLine($"ISP assigned REAL EXTERNAL IP to your router, response from: {pingResult?.Address}, status: {pingResult?.Status}");
            }
            else
            {
                Console.WriteLine($"Your router appears to be behind ISP networks, response from: {pingResult?.Address}, status: {pingResult?.Status}");
            }
        }
    }
    catch (Exception exc)
    {
        Console.WriteLine("Failed to resolve external ip address by ping");
    }
