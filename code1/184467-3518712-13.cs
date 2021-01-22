    protected void OnPaused()
    {
        foreach (EventHandler handler in _pausedHandlers)
        {
            try
            {
                handler(this, EventArgs.Empty);
            }
            catch
            {
                // up to you what to do here
            }
        }
    }
