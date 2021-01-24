    using (GraphicsPath path = new GraphicsPath())
    {
        PointF[] points = new PointF[] {
        new PointF(48.5f, 196.5f),
        new PointF(997.5f, 196.5f),
        new PointF(997.5f, 692.5f),
        new PointF(48.5f, 692.5f),
        };
        path.StartFigure();
        path.AddPolygon(points);
        path.CloseFigure();
        e.Graphics.DrawPath(new Pen(Color.Black, 2), path);
    };
