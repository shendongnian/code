    public List<Command> clients; // not accessible "Command"
    
    public Listener()
    {
        clients = new List<Client>();
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }
