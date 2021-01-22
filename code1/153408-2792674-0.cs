    public Form1()
    {
        InitializeComponent();
        Rectangle r1 = new Rectangle(button1.Location, button1.Size);
        Rectangle r2 = new Rectangle(button2.Location, button2.Size);
        GraphicsPath gp = new GraphicsPath();
        gp.AddRectangle(r1);
        gp.AddRectangle(r2);
        this.Region = new Region(gp);
    }
