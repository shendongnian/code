    private void TextBox1_Changed(object sender, EventArgs e)
    {
    	Validate();
    }
    
    private void ComboBox2_Changed(object sender, EventArgs e)
    {
    	Validate();
    }
    
    private void Validate()
    {
    	if(ValidationOk)
    	{
    		Button1.Enabled = true;
    	}
    	
    	Button1.Enabled = false;
    }
