    public class SocketState
    {
      public SocketState(Socket s)
      {
        this._socket = s;
      }
    
       private Socket _socket;
       public Socket Socket
       {
         get{return _socket;}
       }
    }
    
    
    void SomeFunction()
    {
    //do some stuff in your code
    
    SocketState stateObject = new SocketState(mySocket);
    mySocket.BeginReceive(buffer, offset, size, flags, CallBack, stateObject);
    //do some other stuff
    }
    
    public void CallBack(IAsyncResult result)
    {
      SocketState state = (SocketState)result.AsyncState;
      state.Socket.EndReceive(result);
    
      //do stuff with your socket.
      if(state.Socket.Available)
        mySocket.BeginReceive(buffer, offset, size, flags, CallBack, state);
    }
