    protected override void WndProc(ref Message m) 
    {
        // Listen for operating system messages.
        switch (m.Msg)
        {
            // The WM_ACTIVATEAPP message occurs when the application
            // becomes the active application or becomes inactive.
            case WM_ACTIVATEAPP:
                // The WParam value identifies what is occurring.
                appActive = (((int)m.WParam != 0));
                // Invalidate to get new text painted.
                this.Invalidate();
                break;                
        }        
        base.WndProc(ref m);
    }
