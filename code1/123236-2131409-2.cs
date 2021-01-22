    protected virtual OnSomeEvent(EventArgs e)
    {
        SomeEventHandler handler;
        lock (someEventLock)
        {
            handler = someEvent;
        }
        if (handler != null)
        {
            handler (this, e);
        }
    }
