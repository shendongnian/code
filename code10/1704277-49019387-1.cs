        public void Stuur() // does the sending
        {
              System.Threading.Thread.Sleep(5000);
              SendKeys.Send(textBox3.Text);
              SendKeys.Send("{ENTER}");
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) 
        { 
            for (int i = 0; i <= Int32.Parse(textBox.Text4); i++) {
                Stuur();
            }
        }
        private void button2_Click(object sender, EventArgs e) // the credit block
        {
            if (textBox6.Visible == true)
            {
                textBox6.Visible = false;
            } 
            else 
            {
                textBox6.Visible = true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
    }
