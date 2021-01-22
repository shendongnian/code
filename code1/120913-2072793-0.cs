    private int _isDisposing;
    public bool IsDisposing
    {
        get
        {
            return this._isDisposing != 0;
        }
    }
    public void Dispose()
    {
        // Side note: I may want to `return` instead of `throw`
        if (Interlocked.CompareExchange(ref _isDisposing, 1, 0) != 0)
            throw new InvalidOperationException("Dispose was recursively called.");
        try
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        finally
        {
            _isDisposing = 0;
        }
    }
