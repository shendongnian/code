	private bool ValidInputs()
	{
		if (string.IsNullOrEmpty(textBox1.Text))
        { 
			MessageBox.Show("Field [Email] can not be empty","Information", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);
			textBox1.Focus();
			return false;
		}
		if (string.IsNullOrEmpty(textBox2.Text))
        { 
			// ...
			return false;
		}
		
		return true;
	}
