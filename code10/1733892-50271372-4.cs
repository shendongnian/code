    private void DrawCircle1(Graphics g, RectangleF DrawingArea)
    {
        DrawingArea.Inflate(-2, -2);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.CompositingQuality = CompositingQuality.HighQuality;
        using (GraphicsPath path = new GraphicsPath())
        {
            path.StartFigure();
            path.AddArc(DrawingArea, 0, 360);
            path.CloseFigure();
            using (Pen p = new Pen(Color.Blue, 2))
                g.DrawPath(p, path);
        }
    }
    private void DrawCircle2(Graphics g, RectangleF DrawingArea)
    {
        DrawingArea.Inflate(-1, -1);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.CompositingQuality = CompositingQuality.HighQuality;
        using (Pen p = new Pen(Color.Red, 2))
            g.DrawEllipse(p, DrawingArea);
    }
