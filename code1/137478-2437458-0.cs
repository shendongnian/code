    var ping = new Ping();
    var options = new PingOptions { DontFragment = true };
    
    //just need some data. this sends 10 bytes.
    var buffer = Encoding.ASCII.GetBytes( new string( 'z', 10 ) );
    var host = "127.0.0.1";
    
    try
    {
    	var reply = ping.Send( host, 60, buffer, options );
    	if ( reply == null )
    	{
    		MessageBox.Show( "Reply was null" );
    		return;
    	}
    
    	if ( reply.Status == IPStatus.Success )
    	{
    		MessageBox.Show( "Ping was successful." );
    	}
    	else
    	{
    		MessageBox.Show( "Ping failed." );
    	}
    }
    catch ( Exception ex )
    {
    	MessageBox.Show( ex.Message );
    }
