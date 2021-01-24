    var image = Image.FromFile(mySourceImageFile);
    var bmp = new Bitmap(240, 240);
    var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    using (var g = Graphics.FromImage(bmp))
    {
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.CompositingMode = CompositingMode.SourceCopy;
        g.Clear(Color.Aqua); // I use this to highlight whole image
        // ... some other codes
        g.DrawImageUnscaledAndClipped(image, rect);
        // ... some other codes
    }
    
    bmp.Save(myDestinationImageFile);
