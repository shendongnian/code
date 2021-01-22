    public interface ITcpClient
    {
       Stream GetStream(); 
       // Anything you need here       
    }
    public class TcpClientAdapter: ITcpClient
    {
       private TcpClient wrappedClient;
       public TcpClientAdapter(TcpClient client)
       {
        wrappedClient = client;
       }
    
       public Stream GetStream()
       {
         return wrappedClient.GetStream();
       }
    }
