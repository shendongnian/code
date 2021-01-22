    private delegate <returnType> YouTubeAPI( <args> )
    private YouTubeAPI func;
    private IAsyncResult ticket;
    
    void YouTubeSearchFunc( string what )
    {
        func = <whatever the you tube call is>
        ticket = func.BeginInvoke( <args needed> );
        // WE MUST do this in order to return flow of control to program
        return;
    }
    
    // later we need to check if the ticket is done and then get it
    if ( ticket.IsComplete == true )
        // get it
    else
        // continue on like normal
