    private void button2_Click(object sender, EventArgs e)
    {
        String username = "motify";
        String password = "0w0";
        if ((textBox1.Text == username) && (textBox2.Text == password))
        {
            MessageBox.Show("Welcome back, Guest!", "NetChecker 0.5");
            this.Hide();
            Form1 frm2 = new Form1();
            frm2.ShowDialog();
        }
        else
        {
            MessageBox.Show("Hit the 'How to login?' button to get login details!", "NetChecker 0.5");
        }
    }
