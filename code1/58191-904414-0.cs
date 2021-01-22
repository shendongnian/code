    /// <summary>
    /// This code captures the 'Alt-F4' and the click to the 'X' on the ControlBox
    /// and forces it to call MyClose() instead of Application.Exit() as it would have.
    /// This fixes issues where the threads will stay alive after the application exits.
    /// </summary>
    public const int SC_CLOSE = 0xF060;
    public const int WM_SYSCOMMAND = 0x0112;
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            MyClose();
        base.WndProc(ref m);
    }
