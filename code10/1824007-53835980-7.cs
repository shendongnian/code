    private const int WM_ACTIVATEAPP = 0x1C;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_ACTIVATEAPP)
        {
            if (m.WParam == IntPtr.Zero)
                BeginInvoke(new Action(() => { Text = "Deactivated"; }));
            else
                BeginInvoke(new Action(() => { Text = "Activated"; }));
        }
        base.WndProc(ref m);
    }
