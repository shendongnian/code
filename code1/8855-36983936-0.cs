    public static class Extensions
    {
    	public static void Invoke(this Control control, Action<Control> del)
    	{
    		if (control.InvokeRequired)
    			control.Invoke(new Action(() => del(control)));
    		else
    			del(control);
    	}
    }
