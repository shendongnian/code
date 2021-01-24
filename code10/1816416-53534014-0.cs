    class Client
    {
      private readonly Socket socket;
      public readonly byte[] ReceiveBuffer = new byte[BUFFFER_SIZE];
    
      public Client(Socket socket)
      {
        this.socket = socket;
      }
    
      public void ReceiveCallback(IAsyncResult AR)
      {
        // Handle the received data as usual
      }
    }
