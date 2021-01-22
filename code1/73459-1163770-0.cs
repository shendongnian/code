    Rectangle bounds = Screen.GetBounds(Point.Empty);
    using(Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
    {
    using(Graphics g = Graphics.FromImage(bitmap))
    {
    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
    }
    bitmap.Save("test.jpg", ImageFormat.Jpeg);
    }
