    private void NumClient_KeyDown(object sender, KeyEventArgs e)
    {		
        // Handle Shift case
        if (Keyboard.Modifiers == ModifierKeys.Shift)
        {
           e.Handled = true;
        }
    
        // Handle all other cases
    	if (!e.Handled && (e.Key < Key.D0 || e.Key > Key.D9))
    	{
    	    if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
    	    {
    	        if (e.Key != Key.Back)
    		    {
    		        e.Handled = true;
    		    }
    	    }
    	}			
    }
