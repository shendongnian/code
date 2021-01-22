    Image src = Image.FromFile("main.gif");
    Bitmap b = new Bitmap(100, 129);
    using (Graphics g = Graphics.FromImage(b))
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(src, 0, 0, 100, 129);
    }
    b.Save("scale.png", ImageFormat.Png);
