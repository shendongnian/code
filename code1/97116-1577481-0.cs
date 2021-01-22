    var target = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
    target.SetResolution(source.HorizontalResolution,
    source.VerticalResolution);
    using (var graphics = Graphics.FromImage(target))
    {
        graphics.Clear(Color.White);
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.DrawImage(source,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, source.Width, source.Height),
            GraphicsUnit.Pixel);
    }
