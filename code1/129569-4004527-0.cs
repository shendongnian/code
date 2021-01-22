    Bitmap d = new Bitmap(c.Width, c.Height);
        
    for (int i = 0; i < c.Width; i++)
    {
        for (int x = 0; x < c.Height; x++)
        {
            Color oc = c.GetPixel(i, x);
            int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
            Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
            d.SetPixel(i, x, nc);
        }
    }
