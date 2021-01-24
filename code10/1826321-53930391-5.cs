    Rectangle ScaledBounds(Control c)
    {
        if (c.Tag == null) return c.Bounds;
        Rectangle old = ((Tuple<Size, Rectangle>)c.Tag).Item2;
        Size frame1 = ((Tuple<Size, Rectangle>)c.Tag).Item1;
        Size frame2 = c.Parent.ClientSize;
        float rx = 1f * frame2.Width / frame1.Width;
        float ry = 1f * frame2.Height / frame1.Height;
        int x = (int)(old.Left * rx);
        int y = (int)(old.Top * ry);
        int w = (int)(old.Width * rx);
        int h = (int)(old.Height * ry);
        return new Rectangle(x,y,w,h);
    }
