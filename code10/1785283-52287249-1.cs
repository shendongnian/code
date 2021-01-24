    public static void AcceptCallback(IAsyncResult ar)    
    {  
        // Signal the main thread to continue.  
        allDone.Set();  
        // Get the socket that handles the client request.  
        Socket listener = (Socket) ar.AsyncState;  
        Socket handler = listener.EndAccept(ar);
        ...
