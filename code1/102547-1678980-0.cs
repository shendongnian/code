    public partial class fmUserName : Form
    {
        public string UserName
        {
            get { return txName.Text; }
        }
        public fmUserName()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
