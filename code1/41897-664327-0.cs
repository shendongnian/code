    private Timer tmrLVScroll;
    private System.ComponentModel.IContainer components;
    private int mintScrollDirection;
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
    const int WM_VSCROLL = 277; // Vertical scroll
    const int SB_LINEUP = 0; // Scrolls one line up
    const int SB_LINEDOWN = 1; // Scrolls one line down
    public ListViewBase()
    {
        InitializeComponent();
    }
    protected void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.tmrLVScroll = new System.Windows.Forms.Timer(this.components);
        this.SuspendLayout();
        // 
        // tmrLVScroll
        // 
        this.tmrLVScroll.Tick += new System.EventHandler(this.tmrLVScroll_Tick);
        // 
        // ListViewBase
        // 
        this.DragOver += new System.Windows.Forms.DragEventHandler(this.ListViewBase_DragOver);
        this.ResumeLayout(false);
    }
    protected void ListViewBase_DragOver(object sender, DragEventArgs e)
    {
        Point position = PointToClient(new Point(e.X, e.Y));
        if (position.Y <= (Font.Height / 2))
        {
            // getting close to top, ensure previous item is visible
            mintScrollDirection = SB_LINEUP;
            tmrLVScroll.Enabled = true;
        }else if (position.Y >= ClientSize.Height - Font.Height / 2)
        { 
            // getting close to bottom, ensure next item is visible
            mintScrollDirection = SB_LINEDOWN;
            tmrLVScroll.Enabled = true;
        }else{
            tmrLVScroll.Enabled = false;
        }
    }
    private void tmrLVScroll_Tick(object sender, EventArgs e)
    {
        SendMessage(Handle, WM_VSCROLL, (IntPtr)mintScrollDirection, IntPtr.Zero);
    }
}
