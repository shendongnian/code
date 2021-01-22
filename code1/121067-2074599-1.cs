    private void SendMessage(string message, Socket socket)
    {
      if(socket.connectionState = States.Connected)
      {
          try{
            // Attempt to Send
          }
          catch(SocketException Ex)
          {
            // Disconenct, Additional Cleanup Etc.
          } 
    }
    }
