    public static IEnumerable<IPAddress> GetTraceRoute(string hostname)
    {
        // following are the defaults for the "traceroute" command in unix.
        const int timeout = 10000;
        const int maxTTL = 30;
        const int bufferSize = 32;
        byte[] buffer = new byte[bufferSize];
        new Random().NextBytes(buffer);
        Ping pinger = new Ping();
        for (int ttl = 1; ttl <= maxTTL; ttl++)
        {
            PingOptions options = new PingOptions(ttl, true);
            PingReply reply = pinger.Send(hostname, timeout, buffer, options);
            if (reply.Status == IPStatus.TtlExpired)
            {
                // TtlExpired means we've found an address, but there are more addresses
                yield return reply.Address;
                continue;
            }
            if (reply.Status == IPStatus.TimedOut)
            {
                // TimedOut means this ttl is no good, we should continue searching
                continue;
            }
            if (reply.Status == IPStatus.Success)
            {
                // Success means the tracert has completed
                yield return reply.Address;
            }
            // if we ever reach here, we're finished, so break
            break;
        }
    }
