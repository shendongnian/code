    IPAddress IP = new IPAddress();
    if(IP.TryParse("127.0.0.1",out IP)){
        Socket s = new Socket(AddressFamily.InterNetwork,
        SocketType.Stream,
        ProtocolType.Tcp);
    
        try{   
            s.Connect(IPs[0], port);
        }
        catch(Exception ex){
            // something went wrong
        }
    }
