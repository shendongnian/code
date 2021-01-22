    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
    // Connect using a timeout (5 seconds)
    
    IAsyncResult result = socket.BeginConnect( sIP, iPort, null, null );
    
    bool success = result.AsyncWaitHandle.WaitOne( 5000, true );
    
    if ( !success )
    {
                // NOTE, MUST CLOSE THE SOCKET
    
                socket.Close();
                throw new ApplicationException("Failed to connect server.");
    }
    
    // Success
    //... 
