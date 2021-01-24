        SerialPort serialPort2;
        public delegate void myDelegate(string sData);
        public Form2(SerialPort SP)
        {
            InitializeComponent();
            serialPort2 = SP;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort2.Open();
                serialPort2.DataReceived += port_OnReceiveData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
       publicstatic void port_OnReceiveData(object sender, 
       System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
            string sData;
            serialPort2.ReadTimeout = 20;
            try
            {
                sData = serialPort2.ReadLine();
                this.BeginInvoke((new myDelegate(Text_Out)), sData);
            }
            catch (Exception ex)
            {
            }
           
        }
