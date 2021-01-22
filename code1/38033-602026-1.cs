    MyBitmapFormat ToMyBitmap(Bitmap b)
    {
        MyBitmapFormat mine = new MyBitmapFormat(b.Width, b.Height);
        for (int y=0; y < b.Height; y++) {
            for (int x=0; x < b.Width; x++) {
                mine.SetPixel(x, y, ColorIsBlackish(b.GetPixel(x, y)));
            }
        }
    }
    bool ColorIsBlackish(Color c)
    {
        return Luminance(c) < 128; // 128 is midline
    }
    int Luminance(c)
    {
        return (int)(0.299 * Color.Red + 0.587 * Color.Green + 0.114 * Color.Blue);
    }
