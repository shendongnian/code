    public class MySocket : ISocket
    {
      System.Net.Sockets.Socket _socket;
    
      public void MySocket(System.Net.Sockets.Socket theSocket)
      {
        _socket = theSocket;
      }
    
      public virtual void Send(byte[] stuffToSend)
      {
        _socket.Send(stuffToSend);
      }
    
    }
