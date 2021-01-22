    public static void InvokeIfRequired(this Control control, MethodInvoker action)
    {
        //When the form, thus the control, isn't visible yet, InvokeRequired returns false, resulting still in a cross-thread exception.
        while (!control.Visible)
        {
            System.Threading.Thread.Sleep(50);
        }
        if (control.InvokeRequired) {
            control.Invoke(action);
        } else {
            action();
        }
    }
