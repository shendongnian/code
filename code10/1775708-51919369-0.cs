    void FirstMethod()
    {
      try
      {
        Connessione("google.com", 80);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Could not connect to server: " + ex.Message);
      }
    }
    
    public void Connessione(string hostname, int port)
    {
      TcpClient tcpSocket = new TcpClient(hostname, port);
      // ... Doing things with tcpSocket
    }
