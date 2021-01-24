    using System.Drawing.Drawing2D;
    ..
    GraphicsPath gp1 = new GraphicsPath();
    GraphicsPath gp2 = new GraphicsPath();
    gp1.AddLine(a, b);
    gp2.AddRectangle(pictureBox1.Bound);
    Region r = new Region(gp1);
    r.Intersect(gp2);
    // now we can test whether the intersection is not empty:
    if (!r.IsEmpty(CreateGraphics())) 
    {
        ...
    }
