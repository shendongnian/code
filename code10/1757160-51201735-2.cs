    private static async Task TCP_IPAndUpdateAsync(string ip, int port, int timeout)
    {// method to call IP-check
        client  = new TcpClient();
        var success = await client.Client.ConnectAsyncWithTimeout(ip, port, timeout);
        if (success)
        {
            lock (lockObj)
            {
                IPs.Add(ip);
            }
        }
    }
