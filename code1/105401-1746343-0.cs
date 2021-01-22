    public static void Main(string[] args)
    {
        Socket s = new Socket(...);
        
        byte[] buffer = new byte[10];
        s.BeginReceive(buffer, 0, 10, SocketFlags.None, new AsyncCallback(OnMessageReceived), buffer);
        Console.ReadKey();
    }
    
    public static void OnMessageReceived(IAsyncResult result)
    {
        // ...
    }
