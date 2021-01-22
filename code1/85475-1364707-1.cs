    private delegate object SafeInvokeCallback(Control control, Delegate method, params object[] parameters);
    public static object SafeInvoke(this Control control, Delegate method, params object[] parameters)
    {
    	if (control == null)
    		throw new ArgumentNullException("control");
    	if (control.InvokeRequired)
    	{
    		IAsyncResult result = null;
    		try { result = control.BeginInvoke(new SafeInvokeCallback(SafeInvoke), control, method, parameters); }
    		catch (InvalidOperationException) { /* This control has not been created or was already (more likely) closed. */ }
    		if (result != null)
    			return control.EndInvoke(result);
    	}
    	else
    	{
    		if (!control.IsDisposed)
    			return method.DynamicInvoke(parameters);
    	}
    	return null;
    }
