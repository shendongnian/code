    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public void ReceiveEvent()
        {
            MessageBox.Show("Event Received");
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmDL f = new frmDL();
            frmDL.Evt += ReceiveEvent;
            f.Show();
            f.Activate();
            Application.DoEvents();
        }
    }
