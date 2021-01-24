    using System.Drawing.Drawing2D;
    ..
    bool Intersects(Point a, Point b, Rectangle r)
    {
        if (Math.Min(a.X, b.X) > r.Right)  return false;   // *
        if (Math.Max(a.X, b.X) < r.Left)   return false;   // *
        if (Math.Min(a.Y, b.Y) > r.Bottom) return false;   // *
        if (Math.Max(a.Y, b.Y) < r.Top)    return false;   // *
        if (r.Contains(a)) return true;   // **
        if (r.Contains(b)) return true;   // **
        using (GraphicsPath gp = new GraphicsPath())
        using (Pen pen = new Pen(Color.Empty, 0.5f))
        using (Region reg = new Region(r))
        using (Graphics g = CreateGraphics())
        {
            gp.AddLine(a,b);
            gp.Widen(pen);   // we need to widen the line path just a little
            reg.Intersect(gp);
            if (reg.IsEmpty(g)) return false;
        }
        return true;
    }
