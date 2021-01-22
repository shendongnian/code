    public static void OnSerialDataReceived(object sender, 
                                            SerialDataReceivedEventArgs args)
    {
      string data = ComPort.ReadExisting();
      Console.Write(data.Replace("\r", "\n"));
    }
    private static void InitializeComPort(string port, int baud)
    {
      ComPort = new SerialPort(port, baud);
      // ComPort.PortName = port;
      // ComPort.BaudRate = baud;
      ComPort.Parity = Parity.None;
      ComPort.StopBits = StopBits.One;
      ComPort.DataBits = 8;
      ComPort.Handshake = Handshake.None;
      ComPort.DataReceived += OnSerialDataReceived;
      ComPort.Open();
    }
