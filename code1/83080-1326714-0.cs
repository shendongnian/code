    System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
    path.AddPolygon(new[]
    {
        new Point(20, 20),
        new Point(40, 10),
        new Point(180, 70),
        new Point(160, 260),
        new Point(80, 140)
    });
    
    this.Region = new Region(path);
