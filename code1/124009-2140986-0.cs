    public Form1()
    {
        InitializeComponent();
        this.MinimumSize = new Size(500, 0);
        this.MaximumSize = new Size(500, Screen.AllScreens.Max(s => s.Bounds.Height));
    }
