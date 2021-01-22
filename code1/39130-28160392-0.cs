    public static T GetControl<T>(this Control control, string id) where T:Control
    {
    	var result = control.Controls.Flatten(c => (c.GetType().IsSubclassOf(typeof(T))) && (c.ID == id)).SingleOrDefault();
    	if (result == null)
    		return null;
    	return result as T;
    }
