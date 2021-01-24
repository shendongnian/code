    Thread serverThread;
    static void Main() {
        serverThread = new Thread (Server).Start();       // Run server         
        Thread.Sleep (500);                
        Client();                                         // Run client
    }
    static void Server() {     // Run server on background thread
        while (!serverThread.isInterrupted()) {
            try {
                TcpListener listener = new TcpListener (IPAddress.Any, 8888);
                listener.Start();
           
                using (TcpClient c = listener.AcceptTcpClient())  // waiting clients connected
                using (NetworkStream n = c.GetStream()) {
                    // process client data..
                }
            }
            catch (Exception ex){
                listener.Stop();
                break;
            }
         }                               
     }
   
