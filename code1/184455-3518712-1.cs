    protected void OnPaused()
    {
        EventHandler handler = Paused;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
