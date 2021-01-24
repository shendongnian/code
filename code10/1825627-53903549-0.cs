       public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBox1.ReadOnly = true;
        }
        //as the radio buttons are in a group box they be mutually exclusive
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked || radioButton4.Checked)
            {
                int val = this.radioButton1.Checked ? 0 : 1;
                textBox1.Text = String.Format("Expected msg:{0}", val);
            }
        }
        //as the radio buttons are in a group box will be mutually exclusive
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton3_CheckedChanged(sender, e);
        }
    }
