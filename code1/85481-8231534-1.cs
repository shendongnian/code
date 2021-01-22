    protected override void OnLoad(System.EventArgs e)
    {
        component.Event += new System.EventHandler(myHandler);
    }    
    protected override void OnFormClosing(FormClosedEventArgs e)
    {
        component.Event -= new System.EventHandler(myHandler);
        lock (lockobj)
        {
            closing = true;
        }
    }
    private void Handler(object a, System.EventArgs e)
    {
        lock (lockobj)
        {
            if (closing)
                return;
            this.BeginInvoke(new System.Action(HandlerImpl));
        }
    }
    /*Must be called only on GUI thread*/
    private void HandlerImpl()
    {
        this.Hide();
    }
    private readonly object lockobj = new object();
    private volatile bool closing = false;
