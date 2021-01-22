    private bool _isDisposed = false;
    public void Dispose(bool disposing)
    {
       if (_isDisposed) 
       {
           return;
       }
       _isDisposed = true;
       if (disposing)
       {
            GC.SuppressFinalize(this);
       }
       Win32.DestroyHandle(this.gdiCursorBitmapStreamFileHandle);
    }
