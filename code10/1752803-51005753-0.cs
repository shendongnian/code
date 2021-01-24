    public Form1()
    {
        InitializeComponent();
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.MinimumSize = new Size(200, 200);
        this.MaximumSize = new Size(800, 600);
    }
