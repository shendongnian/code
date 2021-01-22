    private void comboBox1_Enter(object sender, EventArgs e)
    {
        this.AcceptButton = null;
    }
    private void comboBox1_Leave(object sender, EventArgs e)
    {
        this.AcceptButton = button1;
    }
    private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                MessageBox.Show("Hello");
            }
        }
