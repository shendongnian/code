    AutoResetEvent connectDone = new AutoResetEvent( false );
    TcpClient client = new TcpClient();
    client.BeginConnect(
        "127.0.0.1", 80,
        new AsyncCallback(
            delegate( IAsyncResult ar ) {
                client.EndConnect( ar );
                connectDone.Set();
            }
        ), client
    );
    if( !connectDone.WaitOne( 2000 ) ) {
        Console.WriteLine( "network connection failed!" );
        Environment.Exit( 0 );
    }
    Stream stream = client.GetStream();
