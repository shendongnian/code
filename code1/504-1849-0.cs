    public Form1()
    {
        InitializeComponent();
        Timer Every4Minutes = new Timer();
        Every4Minutes.Interval = 10;
        Every4Minutes.Tick += new EventHandler(MoveNow);
        Every4Minutes.Start();
    }
    
    void MoveNow(object sender, EventArgs e)
    {
        Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y - 1);
    }
