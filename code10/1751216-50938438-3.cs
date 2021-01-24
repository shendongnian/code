    public partial class InputForm : Form
    {
        DataTransfer transferDel;
        public InputForm(DataTransfer del)
        {
            InitializeComponent();
            transferDel = del;
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            string data = txtInput.Text;
            transferDel.Invoke(data);
            Close();
        }
    }
