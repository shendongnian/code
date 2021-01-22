    protected virtual void OnClick(EventArgs e)
    {
        EventHandler handler;
        lock (someLock)
        {
            handler = _click;
        }
        if (handler != null)
        {
            handler(this, e);
        }
    }
