    private void drawNeedle(Graphics g, float val, Rectangle r, Color c, float length)
    {
        Point pc = new Point(r.X + r.Width / 2, r.Y + r.Height / 2);
        Point p2 = new Point((int)( pc.X + r.Width / 2  * length / 100f), pc.Y);
        using (Pen pen = new Pen(c, 3f)
        { StartCap = LineCap.RoundAnchor, EndCap = LineCap.ArrowAnchor })
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TranslateTransform(pc.X, pc.Y);
            g.RotateTransform(val - (270 - angle / 2));
            g.TranslateTransform(-pc.X, -pc.Y);
            g.DrawLine(pen, pc, p2);
            g.ResetTransform();
        }
    }
