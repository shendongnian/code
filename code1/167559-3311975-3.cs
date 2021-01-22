    private void TextBox1_Validating(object sender, 
      System.ComponentModel.CancelEventArgs e)
    {
    	//just in case a value was pasted, 
    	//we'll need to validate the value
    	if (!Information.IsNumeric(((TextBox)sender).Text)) 
    	{
    		e.Cancel = true;
    	}
    }
