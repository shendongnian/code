    bool SocketConnected(Socket s)
    {
      // Exit if socket is null
      if (s == null)
        return false;
      bool part1 = s.Poll(1000, SelectMode.SelectRead);
      bool part2 = (s.Available == 0);
      if (part1 && part2)
        return false;
      else
      {
        try
        {
          int sentBytesCount = s.Send(new byte[1], 1, 0);
          return sentBytesCount == 1;
        }
        catch
        {
          return false;
        }
      }
    }
	
