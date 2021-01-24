    public partial class Form2 : Form
    {
        public event EventHandler ClearTextBoxOfMainForm;
        public Form2()
        {
            InitializeComponent();
        }
        private void btnClearTextBox_Click(object sender, EventArgs e)
        {
            if (ClearTextBoxOfMainForm != null)
                ClearTextBoxOfMainForm(this, EventArgs.Empty);
        }
    }
