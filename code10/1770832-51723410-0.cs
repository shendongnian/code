    private static void ConnectCallback(IAsyncResult ar) 
    {  
        try 
        {  
            // Retrieve the socket from the state object.  
            client = (Socket) ar.AsyncState;
            //In case, you are using local client object
            //Socket client = (Socket) ar.AsyncState;
            // Complete the connection.  
            client.EndConnect(ar);  
            Console.WriteLine("Socket connected to {0}",  
                client.RemoteEndPoint.ToString());  
            // Signal that the connection has been made.  
            connectDone.Set();  
        } catch (Exception e) 
        {  
            Console.WriteLine(e.ToString());  
        }  
    }  
