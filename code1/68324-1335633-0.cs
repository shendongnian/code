    Bitmap bmp = new Bitmap(1, 1);
    Bitmap orig = (Bitmap)Bitmap.FromFile("path");
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.DrawImage(orig, new Rectangle(0, 0, 1, 1));
    }
    Color pixel = bmp.GetPixel(0, 0);
    // pixel will contain average values for entire orig Bitmap
    byte avgR = pixel.R; // etc.
