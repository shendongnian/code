    Metafile img = new Metafile("D:\\Chrysanthemum.wmf");
    float planScale = 0.06615f;
    float scale = 1200f / (float)img.Width;
    planScale = planScale / scale; ;
    float widht = img.Width * scale;
    float height = img.Height * scale;
    using (var target = new Bitmap((int)widht, (int)height))
    {
        using (var g = Graphics.FromImage(target))
        {
            g.DrawImage(img, 0, 0, (int)widht, (int)height);
        }
    
        for (int x = 0; x < target.Width; x++)
        {
            for (int y = 0; y < target.Height; y++)
            {
                Color white = target.GetPixel(x, y);
                if ((int)white.R > 230 || (int)white.G > 230 || (int)white.B > 230)
                {
                    target.SetPixel(x, y, Color.Black);
                }
            }
        }
    
    target.Save("D:\\image.png", ImageFormat.Png);
    }
