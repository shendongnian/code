    private SerialPort serialPort1 = new SerialPort();
    public void OpenPort()
    {
        serialPort1.PortName = "COM1";
        serialPort1.Encoding = Encoding.ASCII;
        serialPort1.BaudRate = 38400;
        serialPort1.Parity = System.IO.Ports.Parity.None;
        serialPort1.DataBits = 8;
        serialPort1.StopBits = System.IO.Ports.StopBits.One;
        serialPort1.DtrEnable = true;
        serialPort1.Open();
    }
    public void InitializePrinter()
    {
        serialPort1.Write(Char.ConvertFromUtf32(27) + char.ConvertFromUtf32(64));
    }
    public void OpenDrawer()
    {
        serialPort1.Write(char.ConvertFromUtf32(27) +
           char.ConvertFromUtf32(112) + 
           char.ConvertFromUtf32(0) +
           char.ConvertFromUtf32(5) + 
           char.ConvertFromUtf32(5));
    }
 
