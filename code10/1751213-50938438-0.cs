    public delegate void DataTransfer(string data);
    public partial class MainForm : Form
    {
        public DataTransfer transferDelegate;
        InputForm inputForm = null;
        public MainForm()
        {
            InitializeComponent();
            transferDelegate += new DataTransfer(ReceiveInput);
        }
        public void ReceiveInput(string data)
        {
            txtDisplay.Text = data;
        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            inputForm = new InputForm(transferDelegate);
            inputForm.Show();
        }
    }
