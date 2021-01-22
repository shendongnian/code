    public Control FindControlRecursive(Control rootControl, string controlId)
    {
    	if (rootControl.ID == controlId)
    		return rootControl;
    
    	foreach (Control control in rootControl.Controls)
    	{
    		Control foundControl = FindControlRecursive(control, controlId);
    		if (foundControl != null)
    		{
    			return foundControl;
    		}
    	}
    
    	return null;
    }
    
    public Control FindControlRecursive(Control rootControl, Type type)
    {
    	if (rootControl.GetType().Equals(type))
    		return rootControl;
    
    	foreach (Control control in rootControl.Controls)
    	{
    		Control foundControl = FindControlRecursive(control, type);
    		if (foundControl != null)
    		{
    			return foundControl;
    		}
    	}
    
    	return null;
    }
