    public partial class MyGUI : Form
    {
        private MySerialPort MyPort = new MySerialPort();
    
        public MyGUI()
        {
            InitializeComponent();
            MyPort.OnDataBufferUpdate += DisplayNewData;
        }
    
        public void DisplayNewData(object sender, string args)
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
    
        public DataMode CurrentDataMode
        {
            get { return _CurrentDataMode; }
            set { _CurrentDataMode = value; }
        }
    
        public string DataBuffer
        {
            get { return _DataBuffer; }
            set { _DataBuffer = value; }
        }
    
        public MySerialPort()
        {
            _Port = new SerialPort("COM6", 9600, Parity.None, 8, StopBits.One);
            _Port.Open();
        }
    
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }
    
        public delegate void HandleDataBufferUpdate(object sender, string myValue);
        public event HandleDataBufferUpdate OnDataBufferUpdate = delegate {};
    
        private void _Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_Port.IsOpen) return;
            if (_CurrentDataMode == DataMode.Text)
            {
                // Read all the data waiting in the buffer
                _DataBuffer = _Port.ReadExisting();
            }
            else
            {
                int bytes = _Port.BytesToRead;
                byte[] buffer = new byte[bytes];
                _Port.Read(buffer, 0, bytes);
                _DataBuffer = ByteArrayToHexString(buffer);
            }
            OnDataBufferUpdate(this, "foo" =====> OR EventArgs.Empty);
        }
    }
