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
            memoEdit.Text = MyPort.DataBuffer;
        }
    }
    
    public class MySerialPort
    {
        public enum DataMode {Bin=1, Hex, Text};
    
        private SerialPort _Port = new SerialPort();
        private DataMode _CurrentDataMode = DataMode.Text;
        private string _DataBuffer = String.Empty;
    
        public DataMode CurrentDataMode { // get, set property }
    
        public string DataBuffer { // get, set property }
    
        public MySerialPort()
        {
            _Port = new SerialPort("COM6", 9600, Parity.None, 8, StopBits.One);
            _Port.DataReceived += _Port_DataReceived;
            _Port.Open();
        }
    
        private string ByteArrayToHexString(byte[] data)
        {
            // Turn byte array into hex string
        }
    
        public delegate void HandleDataBufferUpdate(object sender, EventArgs e);
        public event HandleDataBufferUpdate OnDataBufferUpdate = delegate {};
    
        private void _Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Set _Port.DataBuffer from serial port buffer, then activate event below to signal form
            OnDataBufferUpdate(this, EventArgs.Empty);
        }
    }
