    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '+')
        {
            comboBox1.Text = "+";
            textBox2.Focus();
            textBox2.SelectAll();
        }
        else if (e.KeyChar == '-')
        {
            comboBox1.Text = "-";
            textBox2.Focus();
            textBox2.SelectAll();
        }
        else if (e.KeyChar == '*')
        {
            comboBox1.Text = "*";
            textBox2.Focus();
            textBox2.SelectAll();
        }
        else if (e.KeyChar == '/')
        {
            comboBox1.Text = "/";
            textBox2.Focus();
            textBox2.SelectAll();
        }
    }
