    protected virtual void Dispose(bool disposing)
    {
        // The reason for this type to implement IDisposable is that it contains instances of 
        // types that implement IDisposable (content). 
        if (disposing && !_disposed)
        {
            _disposed = true;
            if (_content != null)
            {
                _content.Dispose();
            }
        }
    }
