    var image = new Bitmap(135, 135, PixelFormat.Format32bppArgb);
    using (var g = Graphics.FromImage(image)) {
        g.Clear(Color.Transparent);
        g.DrawLine(Pens.Red, 0, 0, 135, 135);
    }
