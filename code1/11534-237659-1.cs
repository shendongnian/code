    public new Control FindControl(string id)
    {
    	return FindControl<Control>(Page, id);
    }
    
    public static new T FindControl<T>(Control startingControl, string id) where T : Control
    {
    	Control found = startingControl;
    	if ((string.IsNullOrEmpty(id) || (found == null))) return (T)null; 
    	if (string.Compare(id, found.ID) == 0) return found; 
    	foreach (Control ctl in startingControl.Controls) {
    		found = FindControl<Control>(ctl, id);
    		if ((found != null)) return found; 
    	}
    	return (T)null;
    }
