    TcpClient client = new TcpClient();
    IAsyncResult ar = client.BeginConnect(
        "127.0.0.1", 80,
        new AsyncCallback(
            delegate( IAsyncResult _ar ) {
                client.EndConnect( _ar );
            }
        ), client
    );
    if( !ar.AsyncWaitHandle.WaitOne( 2000, false ) ) {
        Console.WriteLine( "network connection failed!" );
        Environment.Exit( 0 );
    }
    Stream stream = client.GetStream();
