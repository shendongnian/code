    using System.Net;
    using System.Net.Sockets;
    
    public bool CheckServerAvailablity(string serverIPAddress, int port)
    {
      try
      {
        IPHostEntry ipHostEntry = Dns.Resolve(serverIPAddress);
        IPAddress ipAddress = ipHostEntry.AddressList[0];
    
        TcpClient TcpClient = new TcpClient();
        TcpClient.Connect(ipAddress , port);
        TcpClient.Close();
    
        return true;
      }
      catch
      {
        return false;
      }
    } 
