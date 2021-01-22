    public delegate void EmptyHandler();
    public delegate void ParamHandler(params object[] args);
    public static void SafeCall(this Control control, 
                          ParamHandler method, params object[] args)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(method, args);
        }
        else
        {
            method(args);
        }
    }
    public static void SafeCall(this Control control, EmptyHandler method)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(method);
        }
        else
        {
            method();
        }
    }
