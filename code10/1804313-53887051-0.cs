    public event OnServiceReadyHandler OnServiceReady
    {
        add
        {
            lock (onServiceReadyHandler) {
                if (!IsReady)
                    onServiceReadyHandler += value;
                else
                    value(this); 
            }
        }
        // Remove ...
    }
    public void Init()
    {
        // Do stuff
        lock (onServiceReadyHandler) {
            IsReady = true;
        }
        OnServiceReady?.Invoke(this);
    }
