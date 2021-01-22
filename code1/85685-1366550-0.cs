    private void ProcessReceive( SocketAsyncEventArgs e )
    {
        AsyncUserToken token = e.UserToken as AsyncUserToken;
        if( e.ByteTransferred > 0 && e.SocketError == SocketError.Success )
        {
            // .. process normally ..
        }
        else
        {
            CloseClientSocket( e );
        }
    }
    private void CloseClientSocket( SocketAsyncEventArgs e )
    {
        AsyncUserToken token = e.UserToken as AsyncUserToken;
        try
        {
            token.Socket.Shutdown( SocketShutdown.Send );
        }
        // throws error if it's already closed
        catch( Exception ) {}
        token.Socket.Close();
    }
