    public Image AppendBorder(Image original, int borderWidth)
    {
        var borderColor = Color.White;
        var newSize = new Size(
            original.Width + borderWidth * 2,
            original.Height + borderWidth * 2);
        var img = new Bitmap(newSize.Width, newSize.Height);
        var g = Graphics.FromImage(img);
        g.Clear(borderColor);
        g.DrawImage(original, new Point(borderWidth, borderWidth));
        g.Dispose();
        return img;
    }
