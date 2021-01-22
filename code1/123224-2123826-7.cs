    public event EventHandler Click
    {
        add
        {
            lock (someLock)      // Normally generated as lock (this)
            {
                _click += value;
            }
        }
        remove
        {
            lock (someLock)
            {
                _click -= value;
            }
        }
    }
