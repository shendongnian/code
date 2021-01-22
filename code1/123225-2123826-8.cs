    protected virtual void OnClick(EventArgs e)
    {
        EventHandler handler = _click;
        if (handler != null)
        {
            handler(this, e);
        }
    }
