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
            {
                //here passing 'this' means we want to clear textBoxes of this form
                ClearTextBoxOfMainForm(this, EventArgs.Empty);
            }
        }
    }
