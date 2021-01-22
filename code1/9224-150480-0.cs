    public interface ITcpClient
    {
       Stream GetStream(); 
       // Anything you need here       
    }
    public TcpClientAdapter: ITcpClient
    {
       private TcpClient wrappedClient;
       public TcpClientWrapper(TcpClient client)
       {
        wrappedClient = client;
       }
    
       public Stream GetStream()
       {
         return wrappedClient.GetStream();
       }
    }
