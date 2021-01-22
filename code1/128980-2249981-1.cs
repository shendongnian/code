    Point mouseLocation;
    public Form1( )
    {
        InitializeComponent();
    
        this.MouseMove += new MouseEventHandler(Form1_MouseMove);
    }
    
    void Form1_MouseMove(object sender , MouseEventArgs e)
    {
        mouseLocation = e.Location;
    }
