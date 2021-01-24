    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            errorProvider1.SetError(TXBheight, "");
            //NEW NEW NEW
            buttonCancel.CausesValidation = false;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // do what is needed when the button is clicked
        }
        private void TXBheight_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetError(TXBheight, "");
            if (String.IsNullOrEmpty(TXBheight.Text))
            {
                errorProvider1.SetError(TXBheight, "Height is a required field");
                e.Cancel = true;
                return;
            }
            if (int.Parse(TXBheight.Text) < 8)
            {
                errorProvider1.SetError(TXBheight, "Height must be GE 8");
                e.Cancel = true;
                return;
            }
            if (int.Parse(TXBheight.Text) > 32)
            {
                errorProvider1.SetError(TXBheight, "Height must be LE 32");
                e.Cancel = true;
                return;
            }
        }
        private void TXBheight_Validated(object sender, EventArgs e)
        {
            //this event is fired when the data is valid, i.e., 
            // if e.Cancel in the _Validating method is NOT set to cancel
        }
        //NEW NEW NEW
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            Close();
        }
        // NEW #2
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
