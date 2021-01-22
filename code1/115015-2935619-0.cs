        private void richTextBox1_ReadOnlyChanged(object sender, EventArgs e)
        {
            //just here instead of White slect your color
            richTextBox1.BackColor = Color.White;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }
