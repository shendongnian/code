    CanBeDisposed cbd;
    using (cbd = new CanBeDisposed())
    {
        Debug.Assert(!cbd.Disposed); // Best not be disposed yet.
    }
    try
    {
        Debug.Assert(cbd.Disposed); // Expecting an exception.
    }
    catch (Exception ex)
    {
        Debug.Assert(ex is ObjectDisposedException); // Better be the right one.
    }
