    public List<Client.Command> clients; 
    
    public Listener()
    {
    	clients = new List<Client.Command>();
    	s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    	Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }
