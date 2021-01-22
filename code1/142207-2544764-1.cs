    protected override void WndProc(ref Message m)
    {
        const int SW_SHOW = 5;
        if (m.Msg == SW_SHOW)
        {
            //DoSomething();
        }
    
        base.WndProc(ref m);
    }
