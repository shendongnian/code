    public static Boolean HasTransparency(Bitmap bitmap)
    {
        // not an alpha-capable color format. Note that GDI+ indexed images are alpha-capable on the palette.
        if (((ImageFlags)bitmap.Flags & ImageFlags.HasAlpha) == 0)
            return false;
        // Indexed format, and no alpha colours in the images palette: immediate pass.
        if ((bitmap.PixelFormat & PixelFormat.Indexed) != 0 && bitmap.Palette.Entries.All(c => c.A == 255))
            return false;
        // Get the byte data 'as 32-bit ARGB'. This offers a converted version of the image data without modifying the original image.
        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        Int32 stride = data.Stride;
        Int32 len = bitmap.Height * stride;
        Byte[] bytes = new Byte[len];
        Marshal.Copy(data.Scan0, bytes, 0, len);
        bitmap.UnlockBits(data);
        // Check the alpha bytes in the data. Since the data is little-endian, the actual byte order is [BB GG RR AA]
        for (Int32 i = 3; i < len; i += 4)
            if (bytes[i] != 255)
                return true;
        return false;
    }
