    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            //only dispose the graphics object if we created it via the dc.
            if (graphics != null && dc != IntPtr.Zero)
            {
                graphics.Dispose();
            }
        }
        ....
    }
