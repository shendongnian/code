    protected override CreateParams CreateParams
    {
        get
           {
             var cp = base.CreateParams;
             cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
             return cp;
           }
    }
    frmChild()
    {
        ResizeRedraw = true;
        this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
    }
