    public Form1()
    {
        InitializeComponent();
    
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Transparent, Top());
        e.Graphics.FillRectangle(Brushes.Transparent, Left());
        e.Graphics.FillRectangle(Brushes.Transparent, Right());
        e.Graphics.FillRectangle(Brushes.Transparent, Bottom());
    }
    
    private const int HTLEFT = 10;
    private const int HTRIGHT = 11;
    private const int HTTOP = 12;
    private const int HTTOPLEFT = 13;
    private const int HTTOPRIGHT = 14;
    private const int HTBOTTOM = 15;
    private const int HTBOTTOMLEFT = 16;
    private const int HTBOTTOMRIGHT = 17;
    
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == 0x84)
        {
            var mp = this.PointToClient(Cursor.Position);
    
            if (TopLeft().Contains(mp))
                m.Result = (IntPtr)HTTOPLEFT;
            else if (TopRight().Contains(mp))
                m.Result = (IntPtr)HTTOPRIGHT;
            else if (BottomLeft().Contains(mp))
                m.Result = (IntPtr)HTBOTTOMLEFT;
            else if (BottomRight().Contains(mp))
                m.Result = (IntPtr)HTBOTTOMRIGHT;
            else if (Top().Contains(mp))
                m.Result = (IntPtr)HTTOP;
            else if (Left().Contains(mp))
                m.Result = (IntPtr)HTLEFT;
            else if (Right().Contains(mp))
                m.Result = (IntPtr)HTRIGHT;
            else if (Bottom().Contains(mp))
                m.Result = (IntPtr)HTBOTTOM;
        }
    }
    
    private Random rng = new Random();
    public Color randomColour()
    {
        return Color.FromArgb(255, rng.Next(255), rng.Next(255), rng.Next(255));
    }
    
    const int ImaginaryBorderSize = 2;
    
    public new Rectangle Top()
    {
        return new Rectangle(0, 0, this.ClientSize.Width, ImaginaryBorderSize);
    }
    
    public new Rectangle Left()
    {
        return new Rectangle(0, 0, ImaginaryBorderSize, this.ClientSize.Height);
    }
    
    public new Rectangle Bottom()
    {
        return new Rectangle(0, this.ClientSize.Height - ImaginaryBorderSize, this.ClientSize.Width, ImaginaryBorderSize);
    }
    
    public new Rectangle Right()
    {
        return new Rectangle(this.ClientSize.Width - ImaginaryBorderSize, 0, ImaginaryBorderSize, this.ClientSize.Height);
    }
    
    public Rectangle TopLeft()
    {
        return new Rectangle(0, 0, ImaginaryBorderSize, ImaginaryBorderSize);
    }
    
    public Rectangle TopRight()
    {
        return new Rectangle(this.ClientSize.Width - ImaginaryBorderSize, 0, ImaginaryBorderSize, ImaginaryBorderSize);
    }
    
    public Rectangle BottomLeft()
    {
        return new Rectangle(0, this.ClientSize.Height - ImaginaryBorderSize, ImaginaryBorderSize, ImaginaryBorderSize);
    }
    
    public Rectangle BottomRight()
    {
        return new Rectangle(this.ClientSize.Width - ImaginaryBorderSize, this.ClientSize.Height - ImaginaryBorderSize, ImaginaryBorderSize, ImaginaryBorderSize);
    }
