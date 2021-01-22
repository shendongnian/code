    public static void InvokeAction(this Control ctl, Action a)
    {
        if (!ctl.InvokeRequired)
        {
            a();
        }
        else
        {
            ctl.BeginInvoke(new MethodInvoker(a));
        }
    }
