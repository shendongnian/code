    public partial class MyGUI : Form
    {
        private MySerialPort MyPort = new MySerialPort();
    
        public MyGUI()
        {
            InitializeComponent();
            MyPort.OnDataBufferUpdate += DisplayNewData;
        }
    
        public void DisplayNewData(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { DisplayNewData(sender, e); }));
            }
            else
            {
                memoEdit.Text = MyPort.DataBuffer;
            }
        }
    }
    
    public class MySerialPort
    {
        public MySerialPort()
        {
            // Initialize serial port
            _Port.DataReceived += _Port_DataReceived;
        }
    
        public delegate void HandleDataBufferUpdate(object sender, EventArgs e);
        public event HandleDataBufferUpdate OnDataBufferUpdate = delegate {};
    
        private void _Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Set _Port.DataBuffer from serial port buffer, then activate event below to signal form
            OnDataBufferUpdate(this, EventArgs.Empty);
        }
    }
