    public partial class Form1 : Form
    {
        private TextBox focusedTextbox = null;
        public Form1()
        {
            InitializeComponent();
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Enter += textBox_Enter;
            }
        }
        void textBox_Enter(object sender, EventArgs e)
        {
            focusedTextbox = (TextBox)sender;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (focusedTextbox != null)
            {
                // put something in textbox
                focusedTextbox.Text = DateTime.Now.ToString();
            }
        }
    }
