    protected override void DefWndProc(ref Message m)
    {
        if (m.Msg == WM_MOUSEWHEEL && Control.ModifierKeys == Keys.Control)
        {				
    	// Do what you want here			
        }
        else
        {
    	base.DefWndProc(ref m);
        }
    }
