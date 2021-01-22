	// This is  to allow only numbers.
	// This Event Trigger, When key press event occures ,and it only allows the Number and Controls., 
	private void txtEmpExp_KeyPress(object sender, KeyPressEventArgs e)
	{
	    if(Char.IsControl(e.KeyChar)!=true&&Char.IsNumber(e.KeyChar)==false)
	    {
	        e.Handled = true;
	    }
	}
	
	//At key press event it will allows only the Characters and Controls.
	private void txtEmpLocation_KeyPress(object sender, KeyPressEventArgs e)
	{
	    if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
	    {
	        e.Handled = true;
	    }
	}
