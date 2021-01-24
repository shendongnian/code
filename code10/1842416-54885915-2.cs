    public static Bitmap MatrixToGrayImage(Byte[] matrix, Int32 width, Int32 height)
    {
        // Create a new 8bpp bitmap
        Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
        // Get the backing data
        BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
        Int64 scan0 = data.Scan0.ToInt64();
        // Copy the contents of your matrix into the image, line by line.
        for (Int32 y = 0; y < height; y++)
            Marshal.Copy(matrix, y * width, new IntPtr(scan0 + y * data.Stride), width);
        bmp.UnlockBits(data);
        // Get the original palette. Note that this makes a COPY of the ColorPalette object.
        ColorPalette pal = bmp.Palette;
        // Generate grayscale colours:
        for (Int32 i = 0; i < 256; i++)
            pal.Entries[i] = Color.FromArgb(i, i, i);
        // Assign the edited palette to the bitmap.
        bmp.Palette = pal;
        return bmp;
    }
