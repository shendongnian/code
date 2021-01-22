    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_RIGHT = 0xB;
    
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
    
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    
    this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_Form);
