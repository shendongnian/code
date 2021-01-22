    private void Refresh( Object sender, EventArgs args )
    {
        Ping ping = null;
    
        try
        {
            ping = new Ping();
            ping.PingCompleted += PingComplete;
            ping.SendAsync( defaultHost, null );
        }
        catch ( Exception )
        {
            ( (IDisposable)ping ).Dispose();
            this.isAlive = false;
        }
    }
    
    private void PingComplete( Object sender, PingCompletedEventArgs args )
    {
        this.isAlive = ( args.Error == null && args.Reply.Status == IPStatus.Success );
        ( (IDisposable)sender ).Dispose();
    }
