    [DllImport("user32.dll")]
    private static extern Int32 EnableMenuItem ( System.IntPtr hMenu , Int32uIDEnableItem, Int32 uEnable);  
    private const Int32 HTCAPTION = 0×00000002;  
    private const Int32 MF_BYCOMMAND =0×00000000;  
    private const Int32 MF_ENABLED =0×00000000;  
    private const Int32 MF_GRAYED =0×00000001;  
    private const Int32 MF_DISABLED =0×00000002; 
    private const Int32 SC_MOVE = 0xF010; 
    private const Int32 WM_NCLBUTTONDOWN = 0xA1;
    private const Int32 WM_SYSCOMMAND = 0×112;
    private const Int32 WM_INITMENUPOPUP = 0×117;
    protected override void WndProc(ref System.Windows.Forms.Message m )
    {
    if (m.Msg == WM_INITMENUPOPUP)
    {
        //handles popup of system menu
        if ((m.LParam.ToInt32() / 65536) != 0) // 'divide by 65536 to get hiword
        {
            Int32 AbleFlags = MF_ENABLED;
            if (!Moveable)
            {
                AbleFlags = MF_DISABLED | MF_GRAYED; // disable the move
            }
            EnableMenuItem(m.WParam, SC_MOVE, MF_BYCOMMAND | AbleFlags);
        }
    }
    if (!Moveable)
    {
        if (m.Msg == WM_NCLBUTTONDOWN) //cancels the drag this is IMP
        {
            if (m.WParam.ToInt32() == HTCAPTION) return;
        }
        if (m.Msg == WM_SYSCOMMAND) // Cancels any clicks on move menu
        {
            if ((m.WParam.ToInt32() & 0xFFF0) == SC_MOVE) return;
        }
    }
    base.WndProc(ref m);
    }  
