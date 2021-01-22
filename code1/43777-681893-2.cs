    while(socket.Connected)
    {
      try
      {
        while (socket.Available == 0)
          System.Threading.Thread.Sleep(100); // Zzzz
      }
      catch (SocketException)
      {
        // connection closed
        // do something
      }
      
      /* Do some processing */
    }
