    private void ReceiveCallback(IAsyncResult result)
    {
      //get our connection from the callback
      xConnection conn = (xConnection)result.AsyncState;
      //catch any errors, we'd better not have any
      try
      {
        //Grab our buffer and count the number of bytes receives
        int bytesRead = conn.socket.EndReceive(result);
        //make sure we've read something, if we haven't it supposadly means that the client disconnected
        if (bytesRead > 0)
        {
          //put whatever you want to do when you receive data here
          //Queue the next receive
          conn.socket.BeginReceive(conn.buffer, 0, conn.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), conn);
         }
         else
         {
           //Callback run but no data, close the connection
           //supposadly means a disconnect
           //and we still have to close the socket, even though we throw the event later
           conn.socket.Close();
           lock (_sockets)
           {
             _sockets.Remove(conn);
           }
         }
       }
       catch (SocketException e)
       {
         //Something went terribly wrong
         //which shouldn't have happened
         if (conn.socket != null)
         {
           conn.socket.Close();
           lock (_sockets)
           {
             _sockets.Remove(conn);
           }
         }
       }
     }
