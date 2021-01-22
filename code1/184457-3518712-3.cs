    protected void OnPaused()
    {
        if (_paused!= null)
        {
            _paused(this, EventArgs.Empty);
        }
    }
