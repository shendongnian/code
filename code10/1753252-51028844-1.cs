    Rectangle circle;
    List<Panel> panels;
    List<int> angles;
    Point center;
    int radius;
    public Form1()
    {
        InitializeComponent();
        ResizeRedraw = true;
        panels = this.Controls.OfType<Panel>().ToList();
        angles = new List<int> { 90, 130, 170, 210, 250, 290, 330, 370, 410 };
        center = new Point(300, 300);
        radius = 200;
        circle = new Rectangle(center.X - radius, center.Y - radius,
            2 * radius, 2 * radius);
        for (int i = 0; i < 9; i++)
        {
            //x = r * cos(a)
            //y = r * sin(a)
            var x = (int)(radius * Math.Cos(Math.PI * angles[i] / 180.0)) + center.X;
            var y = center.Y - (int)(radius * Math.Sin(Math.PI * angles[i] / 180.0));
            panels[i].Left = x - (panels[i].Width / 2);
            panels[i].Top = y - (panels[i].Height / 2);
        }
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.DrawEllipse(Pens.Red, circle);
    }
