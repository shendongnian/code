    public bool Start()
    {
      System.Net.IPHostEntry localhost = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
      System.Net.IPEndPoint serverEndPoint;
      try
      {
         serverEndPoint = new System.Net.IPEndPoint(localhost.AddressList[0], _port);
      }
      catch (System.ArgumentOutOfRangeException e)
      {
        throw new ArgumentOutOfRangeException("Port number entered would seem to be invalid, should be between 1024 and 65000", e);
      }
      try
      {
        _serverSocket = new System.Net.Sockets.Socket(serverEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
       }
       catch (System.Net.Sockets.SocketException e)
       {
          throw new ApplicationException("Could not create socket, check to make sure not duplicating port", e);
        }
        try
        {
          _serverSocket.Bind(serverEndPoint);
          _serverSocket.Listen(_backlog);
        }
        catch (Exception e)
        {
           throw new ApplicationException("Error occured while binding socket, check inner exception", e);
        }
        try
        {
           //warning, only call this once, this is a bug in .net 2.0 that breaks if 
           // you're running multiple asynch accepts, this bug may be fixed, but
           // it was a major pain in the ass previously, so make sure there is only one
           //BeginAccept running
           _serverSocket.BeginAccept(new AsyncCallback(acceptCallback), _serverSocket);
        }
        catch (Exception e)
        {
           throw new ApplicationException("Error occured starting listeners, check inner exception", e);
        }
        return true;
     }
