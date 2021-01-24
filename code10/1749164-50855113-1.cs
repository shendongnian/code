    void DrawStuff(Graphics g)
    {
        bool isZoomed = g.Transform.Elements[0] != 1;
        Rectangle r =  new Rectangle(10, 10, 500, 800);  // some size
        if (isZoomed) g.Clear(Color.Gainsboro);   // pick your back color
        using (Font f = new Font("Tahoma", 11f))
            g.DrawString(text, f, Brushes.DarkSlateBlue, r);
    }
