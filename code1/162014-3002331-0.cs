    static Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();
    
    //This method is executed in a thread
    void ProcessRequest(TcpClient client)
    {
       string ip = null;
       //TODO: get client IP address
       lock (clients)
       {
          ...
          if (clients.ContainsKey(ip))
          {
             //TODO: Deny connection
             return;
          }
          else
          {
             clients.Add(ip, client);
          }
       }
       //TODO: Answer the client
    }
    //TODO: Delete client from list on disconnection
