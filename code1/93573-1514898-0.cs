    System.Drawing.Imaging.BitmapData data =
        bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
        System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
    unsafe
    {
        // important to use the BitmapData object's Width and Height
        // properties instead of the Bitmap's.
        for (int x = 0; x < data.Width; x++)
        {
            int columnOffset = x * 4;
            for (int y = 0; y < data.Height; y++)
            {
                byte* row = (byte*)data.Scan0 + (y * data.Stride);
                byte B = row[columnOffset];
                byte G = row[columnOffset + 1];
                byte R = row[columnOffset + 2];
                byte alpha = row[columnOffset + 3];
            }
        }
    }
    bmp.UnlockBits(data);
