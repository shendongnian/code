    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
       // *always* let the base class process the message
       base.WndProc(ref m);
    
       const int WM_NCHITTEST = 0x84;
       const int HTCAPTION = 2;
       const int HTCLIENT = 1;
    
       // if Windows is querying where the mouse is and the base form class said
       // it's on the client area, let's cheat and say it's on the title bar instead
       if ( m.Msg == WM_NCHITTEST && m.Result.ToInt32() == HTCLIENT )
          m.Result = new IntPtr(HTCAPTION);
    }
