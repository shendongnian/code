    private void YourRichTextBox_KeyDown(object sender, KeyEventArgs e)
    {
    	if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.I)
    	{
    		// do whatever you want to do here...
    		e.SuppressKeyPress = true;
    	}
    }
