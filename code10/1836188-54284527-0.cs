    namespace BarcodeReceivingApp { 
    public class TelnetConnection { 
    private Thread _readWriteThread;
    private TcpClient _client;
    private NetworkStream _networkStream;
    private string _hostname;
    private int _port;
    public TelnetConnection(string hostname, int port)
    {
        this._hostname = hostname;
        this._port = port;
    }
    public void ServerSocket(string ip, int port,Form f)
    {
        try
        {
            _client = new TcpClient(ip, port);         
        }
        catch (SocketException)
        {
            MessageBox.Show(@"Failed to connect to server");
            return;
        }
        //Assign networkstream
        _networkStream = _client.GetStream();
        //start socket read/write thread
        _readWriteThread = new Thread(ReadWrite(f));
        _readWriteThread.Start();
    }
    public void ReadWrite(Form f)
    {
        //Set up connection loop
        while (true)
        {
            var command = "test";
            if (command == "STOP1")
                break;
            //write(command);
             var received = Read();
            f.lst_BarcodeScan.Items.Add(received);
        }
    }
    public string Read()
    {
        byte[] data = new byte[1024];
        var received = "";
        var size = _networkStream.Read(data, 0, data.Length);
        received = Encoding.ASCII.GetString(data, 0, size);
        return received;
    }
    public void CloseConnection()
    {
        _networkStream.Close();
        _client.Close();
    }
