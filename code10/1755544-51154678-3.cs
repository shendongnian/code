    public static Boolean IsGrayscale(Bitmap cur)
    {
        // Indexed format, and no non-gray colours in the images palette: immediate pass.
        if ((cur.PixelFormat & PixelFormat.Indexed) == PixelFormat.Indexed
            && cur.Palette.Entries.All(c => c.R == c.G && c.R == c.B))
            return true;
        BitmapData curBitmapData = cur.LockBits(new Rectangle(0, 0, cur.Width, cur.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        Int32 stride = curBitmapData.Stride;
        Byte[] data = new Byte[stride * cur.Height];
        Marshal.Copy(curBitmapData.Scan0, data, 0, data.Length);
        cur.UnlockBits(curBitmapData);
        Int32 curRowOffs = 0;
        for (Int32 y = 0; y < cur.Height; y++)
        {
            // Set offset to start of current row
            Int32 curOffs = curRowOffs;
            for (Int32 x = 0; x < cur.Width; x++)
            {
                Byte b = data[curOffs];
                Byte g = data[curOffs + 1];
                Byte r = data[curOffs + 2];
                Byte a = data[curOffs + 3];
                // Increase offset to next colour
                curOffs += 4;
                if (a == 0)
                    continue;
                if (r != g || r != b)
                    return false;
            }
            // Increase row offset
            curRowOffs += stride;
        }
        return true;
    }
