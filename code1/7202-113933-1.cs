    public const int WM_NCHITTEST = 0x84;
    public const int HTTRANSPARENT = -1;
    
    protected override void WndProc(ref Message message)
    {
        if ( message.Msg == (int)WM_NCHITTEST )
        {
            message.Result = (IntPtr)HTTRANSPARENT;
        }
        else
        {
            base.WndProc( ref message );
        }
    }
