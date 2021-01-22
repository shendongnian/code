    public void client(string directionIP, string message) //directionIP is the IP from the computer to which i want to get connected
    {
        try
        {
            byte[] bytesSend = System.Text.Encoding.Unicode.GetBytes(message);
            IPAddress direction = IPAddress.Parse(directionIP);
            IPEndPoint directionPort = new IPEndPoint(direction, 5656);
            using (Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socketClient.Connect(directionPort);
                socketClient.Send(bytesSend);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Client error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
