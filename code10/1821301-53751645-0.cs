        public sealed partial class MainPage : Page
    {
        private SerialDevice SerialPort;
        private DataWriter dataWriter;
        private DataReader dataReader;
        string rxBuffer;     
        CancellationTokenSource ReadCancellationTokenSource = new CancellationTokenSource();
        public MainPage()
        {
            this.InitializeComponent();
            InitSerial();   
        }
        private async void InitSerial()
        {
            string aqs = SerialDevice.GetDeviceSelector("UART0");
            var dis = await DeviceInformation.FindAllAsync(aqs);
            SerialPort = await SerialDevice.FromIdAsync(dis[0].Id);
            SerialPort.WriteTimeout = TimeSpan.FromMilliseconds(1000);
            SerialPort.ReadTimeout = TimeSpan.FromMilliseconds(1000);
            SerialPort.BaudRate = 9600;
            SerialPort.Parity = SerialParity.None;
            SerialPort.StopBits = SerialStopBitCount.One;
            SerialPort.DataBits = 8;
            dataWriter = new DataWriter();
            //dataReader = new DataReader(SerialPort.InputStream);
            Listen();
        }
        public async void SerialReceived()
        {
            /* Read data in from the serial port*/
            const uint maxReadLength = 1024;
            dataReader = new DataReader(SerialPort.InputStream);
            uint bytesToRead = await dataReader.LoadAsync(maxReadLength);
            rxBuffer = dataReader.ReadString(bytesToRead);
            receivedData.Text = rxBuffer;
        }
        public async void SerialSend(string txBuffer2)
        {
            /* Write a string out over serial */
            string txBuffer = txBuffer2;
            dataWriter.WriteString(txBuffer);
            uint bytesWritten = await SerialPort.OutputStream.WriteAsync(dataWriter.DetachBuffer());
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SerialSend("Hello Serial");
        }
        private async void Listen()
        {
            try
            {
                if (SerialPort != null)
                {
                    dataReader = new DataReader(SerialPort.InputStream);
                    // keep reading the serial input
                    while (true)
                    {
                        await ReadAsync(ReadCancellationTokenSource.Token);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Uart Error", ex);
            }
        }
        private async Task ReadAsync(CancellationToken cancellationToken)
        {
            Task<UInt32> loadAsyncTask;
            uint ReadBufferLength = 1024;
            // If task cancellation was requested, comply
            cancellationToken.ThrowIfCancellationRequested();
            // Set InputStreamOptions to complete the asynchronous read operation when one or more bytes is available
            dataReader.InputStreamOptions = InputStreamOptions.Partial;
            // Create a task object to wait for data on the serialPort.InputStream
            loadAsyncTask = dataReader.LoadAsync(ReadBufferLength).AsTask(cancellationToken);
            // Launch the task and wait
            UInt32 bytesRead = await loadAsyncTask;
            if (bytesRead > 0)
            {
                receivedData.Text = dataReader.ReadString(bytesRead);
            }
        }
    }
