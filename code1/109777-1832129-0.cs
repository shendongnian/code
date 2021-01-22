    protected override void OnSelectedIndexChanged(EventArgs e)
    {                       
           CancelEventArgs cArgs = new CancelEventArgs();
           OnSelectedIndexChanged(cArgs); // Clearly calling yourself indefinitely.
           //...
    }
