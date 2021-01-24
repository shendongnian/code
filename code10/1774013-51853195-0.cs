        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.KeyDown += new KeyEventHandler(tb_KeyDown);
        }
        static void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               MessageBox.Show(" some junk");
            }
        }
