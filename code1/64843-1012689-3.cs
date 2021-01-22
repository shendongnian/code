	private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == 'a')
		{
	        e.Handled = true;
		}
	}
	private void textBox1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.A)
		{
			e.Handled = true;
			SendKeys.Send("s");
		}
	}
