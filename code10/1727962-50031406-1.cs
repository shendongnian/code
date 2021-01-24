    public async Task PingForeverAsync( IPAddress host )
    {
        Ping ping = new Ping();
        while( true )
        {
            Task interval = Task.Delay( 5000 );
            Task<PingReply> pingTask = ping.SendAsync( host, 5000 );
            PingReply reply = await pingTask.ConfigureAwait(false);
            // (Measure the reply time here and send out notification if necessary)
            await interval.ConfigureAwait(false); // await the 5000ms interval delay
        }
    }
