    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ActiveateButton()
        {
            this.button1.Enabled = textBox1.Text != string.Empty;
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ActiveateButton();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ActiveateButton();
        }
    }
