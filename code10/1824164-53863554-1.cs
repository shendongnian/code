        public Form1()
        {
            InitializeComponent();
            serialPort.Open();
        }
        void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                String data = serialPort.ReadExisting();
                CheckForIllegalCrossThreadCalls = false;
                txtInData.Text += data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serial Port Read Error: " + ex.ToString(), "Error");
            }
        }
