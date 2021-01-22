    private static PhysicalAddress GetCurrentMAC(string allowedURL)
    {
      TcpClient client = new TcpClient();
      client.Client.Connect(new IPEndPoint(Dns.GetHostAddresses(allowedURL)[0], 80));
      while(!client.Connected)
      {
        Thread.Sleep(500);  
      }
      IPAddress address2 = ((IPEndPoint)client.Client.LocalEndPoint).Address;
      client.Client.Disconnect(false);
      NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
      client.Close();
      if(allNetworkInterfaces.Length > 0)
      {
        foreach(NetworkInterface interface2 in allNetworkInterfaces)
        {
          UnicastIPAddressInformationCollection unicastAddresses = interface2.GetIPProperties().UnicastAddresses;
          if((unicastAddresses != null) && (unicastAddresses.Count > 0))
          {
            for(int i = 0; i < unicastAddresses.Count; i++)
              if(unicastAddresses[i].Address.Equals(address2))
                return interface2.GetPhysicalAddress();
          }
        }
      }
      return null;
    }
