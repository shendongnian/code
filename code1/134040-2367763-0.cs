    public static void InvokeIfRequired(this Control c, Action<Control> action)
    {
    	if(c.InvokeRequired)
    	{
    		c.Invoke(() => action(c));
    	}
    	else
    	{
    		action(c);
    	}
    }
