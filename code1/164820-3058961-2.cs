    public class SerialPortConnection : IDisposable
    {
        private bool disposed;
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
            // Do whatever with the error, maybe need to reopen the socket.
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.Port.Close();
                    this.Port.Dispose(disposing);
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            this.Dispose(true);
        }
    }
