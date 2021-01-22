    public static class Extensions
    {
    	public static void Invoke<TControlType>(this TControlType control, Action<TControlType> del) 
    		where TControlType : Control
    		{
    			if (control.InvokeRequired)
    				control.Invoke(new Action(() => del(control)));
    			else
    				del(control);
    	}
    }
