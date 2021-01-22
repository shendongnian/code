    Image src = Image.FromFile("main.gif");
    Bitmap dst = new Bitmap(100, 129);
    using (Graphics g = Graphics.FromImage(dst))
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(src, 0, 0, b.Width, b.Height);
    }
    dst.Save("scale.png", ImageFormat.Png);
