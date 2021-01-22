    protected virtual void Dispose(bool disposing)
    {
        if (!_Disposed)
        {
            if (disposing && (_Writer != null))
            {
                _Writer.Dispose();
            }
            _Writer = null;
            _Disposed = true;
        }
    }
