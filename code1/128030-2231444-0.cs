    class NumericTextBox : System.Windows.Forms.TextBox
    {
    	protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
    	{
    		base.OnKeyPress(e);
    
    		if (true /* insert your conditions */)
    			e.Handled = true;
    	}
    }
