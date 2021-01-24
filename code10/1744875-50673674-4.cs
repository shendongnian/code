    public partial class MainForm : Form
    {
        private Connect connectForm;
        public MainForm()
        {
            InitializeComponent();
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect connect;
            if (connectForm==null)
            {
                connectForm = new Connect();
            }
            connect = connectForm;
            connect.ShowDialog();
            if (connect.Connect_Status == true)
            {
                lb_Comm.Text = String.Format("Connected to '{0}'", connect.cb_CommPort.SelectedItem);
            }
            else
            {
                CommPortManager.Instance.COM_Close();
                lb_Comm.Text = "Not Connected";
            }
        }
    }
