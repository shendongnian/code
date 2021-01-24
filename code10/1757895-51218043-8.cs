    using System.Drawing.Drawing2D;
    ..
    GraphicsPath gp1 = new GraphicsPath();
    GraphicsPath gp2 = new GraphicsPath();
    gp1.AddLine(a, b);
    gp2.Widen(new Pen(Color.Empty, 0.5f))   // we need to widen the line path a little
    gp2.AddRectangle(pictureBox1.Bound);
    Region r = new Region(gp1);
    r.Intersect(gp2);
    // now we can test whether the intersection is not empty:
    if (!r.IsEmpty(CreateGraphics())) 
    {
        ...
    }
