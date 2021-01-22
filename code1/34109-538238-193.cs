    public void Dispose(bool disposing)
    {
       if (disposing)
       {
            GC.SuppressFinalize(this);
       }
       Win32.DestroyHandle(this.gdiCursorBitmapStreamFileHandle);
    }
    public void Dispose()
    {
        Dispose(true);
    }
    public void Finalize()
    {
        Dispose(false);
    }
