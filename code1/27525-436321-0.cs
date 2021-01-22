    struct SocketStateObject
    {
      public byte[] Buffer;
      public Socket Socket;
    }
    
    Socket mySocket = new Socket(...);
    SocketStateObject state;
    state.Buffer = new byte[1024];
    state.Socket = mySocket;
    
    socket.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, callback, state);
    
    //don't remember the signature
    public void callback(IAsyncResult a)
    {
      if (((SocketStateObject)a.State).Buffer.Length = 0)
        //don't call socket.beginreceive again.
    }
