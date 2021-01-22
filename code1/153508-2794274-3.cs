    public static void MaybeInvoke(this Control c, Action action)
    {
       if (c.InvokeRequired)
       {
           this.BeginInvoke(action);
       }
       else
       {
           action();
       }
    }
