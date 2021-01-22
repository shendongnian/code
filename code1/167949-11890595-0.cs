       public class CommSERIAL : IComm
        {
    
            #region Events
  
            public event EventHandler EvtOnConnect;
            public event EventHandler EvtOnDisconnect;
    
            public event EventHandler<OnDataReceivedEventArgs> EvtOnDataReceived;
    
            #endregion
    
            System.IO.Ports.SerialPort Rs232 = new System.IO.Ports.SerialPort();
    
    
            private string m_Port;
    
            public string Port
            {
                get { return m_Port; }
                set { m_Port = value; }
            }
            private int m_Baud;
    
            public int Baud
            {
                get { return m_Baud; }
                set { m_Baud = value; }
            }
    
            private int m_DataBit;
    
            public int DataBit
            {
                get { return m_DataBit; }
                set { m_DataBit = value; }
            }
    
            private System.IO.Ports.StopBits m_stopBits;
    
            public System.IO.Ports.StopBits StopBits
            {
                get { return m_stopBits; }
                set { m_stopBits = value; }
            }
    
            private System.IO.Ports.Parity m_parity;
    
            public System.IO.Ports.Parity Parity
            {
                get { return m_parity; }
                set { m_parity = value; }
            }
    
    
            public void Connect()
            {
                if (!(Rs232.IsOpen))
                {
                    Rs232.PortName = this.Port;
                    Rs232.BaudRate = this.Baud; ;
                    Rs232.DataBits = this.DataBit;
                    Rs232.StopBits = this.StopBits;
                    Rs232.Parity = this.Parity;
                    Rs232.ReadTimeout = 5000;
                    Rs232.Handshake = System.IO.Ports.Handshake.None;
                    Rs232.ReadTimeout = 1000;
                    Rs232.WriteTimeout = 500;               
    
                    Rs232.Open();
                    
                   
                }
            }
    
            public void Disconnect()
            {
                Rs232.Close();
                if (EvtOnDisconnect != null)
                    EvtOnDisconnect(new object(), new System.EventArgs());
    
                m_Connected = false;
            }
    
    
            public CommSERIAL()
            {
                this.ConnType = ConnType.Direct;
    
            }
    
    
            public bool Connected
            {
                get
                {
                    return m_Connected;
    
                }
            }
    
    
            private ConnType m_ConnType;
    
            public ConnType ConnType
            {
                get { return m_ConnType; }
                set { m_ConnType = value; }
            }
    
            public string ReadOnByte(int Lenght,char EndChar)
            {
                char[] bytes = new char[Lenght];
                string ret = "";
                int numBytesRead = 0;
                while (bytes[numBytesRead] != EndChar && numBytesRead <= bytes.Length)
                {
                    while (Rs232.Read(bytes, numBytesRead, 1) == 1 && bytes[numBytesRead] != EndChar && numBytesRead <= bytes.Length)
                    {
                        numBytesRead++;
                    }
                }
    
                foreach (char b in bytes)
                    ret += b.ToString();
                return ret.Substring(0,numBytesRead);
    
               
            }
    
            public String ReadBuffer()
            {
    
                try
                {
                    if (Rs232.IsOpen)
                    {
    
                        Byte[] readBuffer = new Byte[Rs232.ReadBufferSize + 1];
    
                        try
                        {
                            // If there are bytes available on the serial port,
                            // Read returns up to "count" bytes, but will not block (wait)
                            // for the remaining bytes. If there are no bytes available
                            // on the serial port, Read will block until at least one byte
                            // is available on the port, up until the ReadTimeout milliseconds
                            // have elapsed, at which time a TimeoutException will be thrown.
                            Int32 count = Rs232.Read(readBuffer, 0, Rs232.ReadBufferSize);
    
                            String SerialIn = System.Text.Encoding.ASCII.GetString(readBuffer, 0, count);
    
                            return SerialIn;
    
                        }
                        catch (TimeoutException) { return ""; }
    
                    }
                    else
                    {
                        Thread.Sleep(50);
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
              
            }
            public string Read()
            {
                return Rs232.ReadExisting();
            }
    
            public string ReadAll()
            {
    
                //TO DO
                return "";
            }
    
            public void Write(string Data)
            {
                if (Rs232 == null)
                    throw new Exception("Must be connected before Write");
    
                if (!Rs232.IsOpen)
                    throw new Exception("Must be opened before Write");
    
                Rs232.Write(Data);
            }
    
            public void ClearBuffer()
            {
                Rs232.DiscardInBuffer();
            }
    
    
            private bool m_Connected;
    
    
            #region IComm Members
    
    
            private int m_Id;
    
            public int Id
            {
                get
                {
                    return m_Id;
                }
    
                set
                {
                    m_Id = value;
                }
            }
    
            #endregion
    
            public override string ToString()
            {
                return this.ConnType.ToString();
            }
    
            #region IComm Members
    
    
           
            #endregion
        }
