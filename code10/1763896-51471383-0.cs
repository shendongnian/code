    public Bitmap ToBitmap2d(double[,] image, PixelFormat pixelFormat)
    {
        int Width = image.GetLength(0);
        int Height = image.GetLength(1);
        Bitmap bmp = new Bitmap(Width, Height, pixelFormat);
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                int i = (int)(image[x, y] * 1);
                if (i > 255) i = 255;
                if (i < 0) i = 0;
                Color clr = Color.FromArgb(i, i, i);
                bmp.SetPixel(x, y, clr);
            }
        }
        return bmp;
    }
