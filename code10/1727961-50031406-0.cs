    public async Task PingForeverAsync( IPAddress host )
    {
        Ping ping = new Ping();
        while( true )
        {
            PingReply reply = await ping.SendAsync( host, 5000 ).ConfigureAwait(false);
            // (Measure the reply time here and send out notification if necessary)
        }
    }
