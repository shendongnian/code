    public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
      this.FormBorderStyle = FormBorderStyle.None; // no borders
      this.DoubleBuffered = true;
      this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
    }
    protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
    {
        e.Graphics.FillRectangle(Brushes.Green, Top);
        e.Graphics.FillRectangle(Brushes.Green, Left);
        e.Graphics.FillRectangle(Brushes.Green, Right);
        e.Graphics.FillRectangle(Brushes.Green, Bottom);
    }
    
    private const int
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17;
    
    const int _ = 10; // you can rename this variable if you like
    
    Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
    Rectangle Left { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
    Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
    Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }
    
    Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
    Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
    Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
    Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }
    
    
    protected override void WndProc(ref Message message)
    {
        base.WndProc(ref message);
    
        if (message.Msg == 0x84) // WM_NCHITTEST
        {
            var cursor = this.PointToClient(Cursor.Position);
    
            if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
       else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
       else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
       else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;
    
       else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
       else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
       else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
       else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
        }
    }}
