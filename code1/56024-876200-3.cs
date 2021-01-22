    public bool Send(byte[] message, xConnection conn)
    {
      if (conn != null && conn.socket.Connected)
      {
        lock (conn.socket)
        {
        //we use a blocking mode send, no async on the outgoing
        //since this is primarily a multithreaded application, shouldn't cause problems to send in blocking mode
           conn.socket.Send(bytes, bytes.Length, SocketFlags.None);
         }
       }
       else
         return false;
       return true;
     }
