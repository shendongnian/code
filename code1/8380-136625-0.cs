    IPAddress[] IPs = Dns.GetHostAddresses(host);
    
    Socket s = new Socket(AddressFamily.InterNetwork,
        SocketType.Stream,
        ProtocolType.Tcp);
    
    try{   
    s.Connect(IPs[0], port);
    }
    catch(Exception ex){
    // something went wrong
    }
   
