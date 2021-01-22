    public class SerialPortConnection : IDisposable
    {
        public SerialPort Port { get; protected set; }
        public SerialPortConnection(int portNo)
        {
            this.Initialize(portNo);
            this.Port.ErrorReceived += this.portError;
            this.Port.Open();
        }
        public void Initialize(int portNo)
        {
            this.Port = new SerialPort();
            this.Port.PortName = "COM" + portNo.ToString();
            /* snip */
            this.Port.Encoding.GetEncoder();
            this.Port.ReceivedBytesThreshold = 1;
            this.Port.NewLine = Environment.NewLine;
        }
        protected void portError(
            object sender, 
            SerialErrorReceivedEventHandler args)
        {
            // do whatever with the error, maybe need to reopen the socket
        }
        public void Dispose()
        {
            this.Port.Close();
        }
    }
