    private Thread GetControlOwnerThread(Control ctrl)
    {
        if (ctrl.InvokeRequired)
            ctrl.BeginInvoke(
                new Action<Control>(GetControlOwnerThread),
                new object[] {ctrl});
        else
            return System.Threading.Thread.CurrentThread;
    }
