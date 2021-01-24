        private TelnetConnection connection;
        private void btn_ConnectT_Click(object sender, EventArgs e)
        {
            connection = new TelnetConnection(Hostname, Port);
            connection.ServerSocket(Hostname, Port, this);
        }
        private void btn_StopConnection_Click(object sender, EventArgs e)
        {
            connection.Exit();
        }
