    private Control _last;
    private void textBox1_Leave(object sender, EventArgs e)
    {
        _last = (Control) sender;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("asdf");
        _last.Focus();
    }
