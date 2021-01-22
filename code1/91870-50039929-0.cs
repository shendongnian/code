    Bitmap bmp = new Bitmap(1, 1);
    Color GetColorAt(int x, int y)
    {
        Rectangle bounds = new Rectangle(x, y, 1, 1);
        using (Graphics g = Graphics.FromImage(bmp))
            g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
        return bmp.GetPixel(0, 0);
    }
