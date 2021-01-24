    private void btn_ConnectT_Click(object sender, EventArgs e)
    {
        var readData = new TelnetConnection(Hostname, Port);
        readData.ServerSocket(Hostname, Port, this);
    }
