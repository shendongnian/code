    using (GraphicsPath path = new GraphicsPath())
    {
        Point[] points = new Point[] {
            new Point(518, 10), new Point(433, 10),
            new Point(433, 40), new Point(433, 40),
            new Point(433, 40), new Point(518, 40)
        };
        path.AddLines(points);
        e.Graphics.DrawPath(new Pen(Color.Black, 2), path);
        //Add a new figure
        path.StartFigure();
        path.AddEllipse(new Rectangle(450, 40, 50, 50));
        e.Graphics.DrawPath(new Pen(Color.Black, 2), path);
    };
