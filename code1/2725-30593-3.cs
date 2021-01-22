    Image src = Image.FromFile("main.gif");
    using (Graphics g = Graphics.FromImage(dst))
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(src, 0, 0, b.Width, b.Height);
    }
    dst.Save("scale.png", ImageFormat.Png);
    dst.Dispose();
    src.Dispose();
