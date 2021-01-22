    public void Dispose()
    {
       Win32.DestroyHandle(this.gdiCursorBitmapStreamFileHandle);
    }
    public void Finalize()
    {
        Dispose();
    }
