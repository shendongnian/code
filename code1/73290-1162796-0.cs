    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
    
        // check if we've already been closed
        if (m_bClosed)
        {
            // close the window now
            Close();
        }
    }
    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
        // make sure close wasn't cancelled
        if (!e.Cancel)
        {
            // mark window as closed
            m_bClosed = true;
        
            // if our source isn't initialized yet, Close won't actually work,
            // so we cancel this close and rely on SourceInitialized to close
            // the window
            if (new WindowInteropHelper(this).Handle == IntPtr.Zero)
                e.Cancel = true;
        }
    }
    bool m_bClosed;
