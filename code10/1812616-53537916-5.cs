    string fn = "D:\\_test18b.emf";
    Image img = Image.FromFile(fn);
    int w = img.Width;
    int h = img.Height;
    float scale = 100;
    Rectangle rScaled = Rectangle.Empty;
    using (Bitmap bmp = new Bitmap((int)(w / scale), (int)(h / scale)))
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.ScaleTransform(1f/scale, 1f/scale);
        g.Clear(Color.Transparent);
        g.DrawImage(img, 0, 0);
        rScaled = getBounds(bmp);
        Rectangle rUnscaled = Rectangle.Round(
             new RectangleF(rScaled.Left * scale, rScaled.Top * scale, 
                            rScaled.Width * scale, rScaled.Height * scale ));
     }
