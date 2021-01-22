    public bool IsDisposed(Control ctrl)
    {
        if (ctrl.IsDisposed)
            return true;
        try
        {
            ctrl.Invoke(new Action(() => { }));
            return false;
        }
        catch (ObjectDisposedException)
        {
            return true;
        }
    }
