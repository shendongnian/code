    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
        try
        {
             IAsyncResult result = socket.BeginConnect("www.xxxxxxxxx.com", 80, null, null );
             //I set it for 3 sec timeout, but if you are on an internal LAN you can probably 
             //drop that down a little because this should be instant if it is going to work
             bool success = result.AsyncWaitHandle.WaitOne( 3000, true );
        
             if ( !success )
             {
                    throw new ApplicationException("Failed to connect server.");
             }
        
             // Success
             //... 
        }
        finally
        {
             //You should always close the socket!
             socket.Close();
        }
