    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '+')
        {
            comboBox1.Text = "+";
            textBox2.Focus();
            textBox2.SelectAll();
        }
        if (e.KeyChar == '-')
        {
            comboBox1.Text = "-";
            textBox2.Focus();
            textBox2.SelectAll();
        }
    
        if (e.KeyChar == '*')
        {
            comboBox1.Text = "*";
            textBox2.Focus();
            textBox2.SelectAll();
        }
    
        if (e.KeyChar == '/')
        {
            comboBox1.Text = "/";
            textBox2.Focus();
            textBox2.SelectAll();
        }
    }
