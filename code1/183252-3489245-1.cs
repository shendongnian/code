    // Extension methods.
    public static void BeginInvoke(this Control control, Action action) {
        if (control.InvokeRequired) control.BeginInvoke(action);
        else action();
    }
    public static void BeginInvoke<T1, T2>(this Control control, Action<T1, T2> action, T1 arg1, T2 arg2) {
        if (control.InvokeRequired) control.BeginInvoke(action, new object[] { arg1, arg2 });
        else action(arg1, arg2);
    }
    // Code elsewhere.
    progressBar1.BeginInvoke(() => SecondTimer_Elapsed(sender, e));
    // Or:
    progressBar1.BeginInvoke(SecondTimer_Elapsed, sender, e);
