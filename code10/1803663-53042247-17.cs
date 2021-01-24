    public void draw(Graphics g, float scale, float size)
    {
        RectangleF r = new RectangleF(VX * scale, VY * scale, size, size);
        g.FillEllipse(Brushes.Beige, r);
        g.DrawEllipse(Pens.Black, r);
        using (StringFormat fmt = new StringFormat()
        { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center})
        using (Font f = new Font("Consolas", 20f))
            g.DrawString(Text, f, Brushes.Blue, r, fmt);
        foreach(var nn in nextNodes)
        {
            using (Pen pen = new Pen(Color.Green, 1f)
            { EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor })
                g.DrawLine(pen, getConnector(this, scale, false, size),
                                getConnector(nn, scale, true, size));
        }
    }
    PointF getConnector(NetNode n, float scale, bool left, float size)
    {
        RectangleF r = new RectangleF(n.VX * scale, n.VY * scale, size, size);
        float x = left ? r.Left : r.Right;
        float y = r.Top + r.Height / 2;
        return new PointF(x, y);
    }
