    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    const int WM_UPDATEUISTATE = 0x0128;
    const int UISF_HIDEACCEL = 0x2;
    const int UIS_CLEAR = 0x2;
    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        ToolStripManager.Renderer = new MyRenderer();
    }
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_UPDATEUISTATE)
            m.WParam = (IntPtr)((UISF_HIDEACCEL & 0x0000FFFF) | (UIS_CLEAR << 16));
        base.WndProc(ref m);
    }
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextFormat &= ~TextFormatFlags.NoPrefix;
            e.TextFormat &= ~TextFormatFlags.HidePrefix;
            base.OnRenderItemText(e);
        }
    }
