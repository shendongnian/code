    class Abc {
      private TcpClient serv1;
      public void Server_connect_button_Click(object sender, EventArgs e)
      {
        //Open CasparCG server connection and create a TCP client
        int port = portnumber;
        serv1 = new TcpClient("localhost", port);
      }
      public void Disconnect_server_button_Click(object sender, EventArgs e)
      {
        if(serv1!=null)
         serv1.Close();
      }
    }
