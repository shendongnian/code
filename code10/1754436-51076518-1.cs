    NetworkStream networkStream;
    TcpClient client;
    byte[] datalength = new byte[4];
    
    public Client()
    {
        InitializeComponent();
        try
        {
            client = new TcpClient("your server ip", 2018);
            ClientSend("unique ID");
        }
         catch (Exception ex)
        {
             MessageBox.Show(ex.Message);
        }
    }
    
    void ClientSend(string msg)
    {
        try
        {
            networkStream = client.GetStream();
            byte[] data;
            data = Encoding.Default.GetBytes(msg);
            int length = data.Length;
            byte[] datalength = new byte[4];
            datalength = BitConverter.GetBytes(length);
            networkStream.Write(datalength, 0, 4);
            networkStream.Write(data, 0, data.Length);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
