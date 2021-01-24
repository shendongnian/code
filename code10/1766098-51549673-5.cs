	public bool TextBoxEmpty(TextBox txtBox, string displayMsg)
	{
		if (string.IsNullOrEmpty(txtBox.Text)) 
		{ 
			MessageBox.Show(displayMsg, "Required field", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);
			txtBox.Focus();
			return true;
		}
		
		return false;
	}
