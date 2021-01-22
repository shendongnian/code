    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
    	if (e.KeyChar == (char)Keys.Enter)
    	{
    		MessageBox.Show("Enter pressed!");
    	}
    }
