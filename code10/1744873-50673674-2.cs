    public partial class MainForm : Form
    {
        private ConnectionObject connectionObject = new ConnectionObject();
        public MainForm()
        {
            InitializeComponent();
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect connect = new Connect(connectionObject);
            connect.ShowDialog();
            if (connectionObject.ConnectionStatus == true)
            {
                lb_Comm.Text = String.Format("Connected to '{0}'", connectionObject.PortName);
            }
            else
            {
                CommPortManager.Instance.COM_Close();
                lb_Comm.Text = "Not Connected";
            }
        }
    }
    public class ConnectionObject
    {
        public string PortName { get; set; }
        public string BaudRate { get; set; }
        public string Parity { get; set; }
        public string StopBits { get; set; }
        public string DataBits { get; set; }
        public bool ConnectionStatus { get; set; }
    }
