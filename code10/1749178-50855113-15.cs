    void DrawStuff(Graphics g)
    {
        bool isZoomed = g.Transform.Elements[0]!= 1   
                    ||  g.Transform.OffsetX != 0 | g.Transform.OffsetY != 0;
        if (isZoomed) g.Clear(Color.Gainsboro);   // pick your back color
        // all your drawing here!
        Rectangle r =  new Rectangle(10, 10, 500, 800);  // some size
        using (Font f = new Font("Tahoma", 11f))
            g.DrawString(text, f, Brushes.DarkSlateBlue, r);
    }
