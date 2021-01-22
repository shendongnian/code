    public void ActionWithInt( int param )
    {
       // some command
    }
    
    Action<int> fp = ActionWithInt;
    
    udpCommand<int>( fp, 10 );  // or whatever.
