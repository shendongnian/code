    protected override void WndProc( ref Message m )
    {
        if( m.Msg == 0x0112 ) // WM_SYSCOMMAND
        {
            // Check your window state here
            if (m.WParam == new IntPtr( 0xF030 ) ) // Maximize event - SC_MAXIMIZE from Winuser.h
            {
                  // THe window is being maximized
            }
        }
        base.WndProc(ref m);
    }
