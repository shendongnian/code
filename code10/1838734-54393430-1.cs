    private const int WM_PASTE = 0x302;
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_PASTE:
                m.HWnd = IntPtr.Zero;
                break;
            default:
                break;
        }
        base.WndProc(ref m);
    }
