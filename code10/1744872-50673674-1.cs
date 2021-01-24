    public partial class Connect : Form
    {
        private ConnectionObject connectionObject;
        public Connect()
        {
            InitializeComponent();
            COM_List();
        }
        public Connect(ConnectionObject connectionObject) : this()
        {
            this.connectionObject = connectionObject;
            //code here to reassign the value;
        }
        private void COM_List()
        {
            for (int i = 0; i < CommPortManager.Instance.GetCommList().Count; i++)
            {
                cb_CommPort.Items.Add(CommPortManager.Instance.GetCommList()[i]);
            }
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            connectionObject.PortName = CommPortManager.Instance.PortName = cb_CommPort.Text;
            connectionObject.BaudRate = CommPortManager.Instance.BaudRate = cb_BaudRate.Text;
            connectionObject.Parity = CommPortManager.Instance.Parity = cb_Parity.Text;
            connectionObject.StopBits = CommPortManager.Instance.StopBits = cb_StopBits.Text;
            connectionObject.DataBits = CommPortManager.Instance.DataBits = cb_DataBits.Text;
            if ((cb_CommPort.Text == "") || (cb_BaudRate.Text == "") || (cb_Parity.Text == "") || (cb_DataBits.Text == "") || (cb_StopBits.Text == ""))
            {
                MessageBox.Show("Please select all communication settings and then Save", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connectionObject.ConnectionStatus =  false;
            }
            else
            {
                if (CommPortManager.Instance.COM_Open() == false)
                {
                    MessageBox.Show("Could not open the COM port. Most likely it is already in use, has been removed, or is unavailable.", "TestCertificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connectionObject.ConnectionStatus =  false;
                }
                else
                {
                    CommPortManager.Instance.COM_Close();
                    connectionObject.ConnectionStatus =  true;
                    btn_Connect.Text = "Disconnect";
                }
            }
        }
    }
