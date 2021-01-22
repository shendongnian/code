    public static Boolean HasTransparency(Bitmap bitmap)
    {
        Int32 flags = bitmap.Flags;
        Boolean hasAplha = (flags & (Int32)ImageFlags.HasAlpha) != 0 || (flags & (Int32)ImageFlags.HasTranslucent) != 0;
        // not an alpha-capable color format.
        if (!hasAplha)
            return false;
        // Paletted types
        if (bitmap.PixelFormat == PixelFormat.Format8bppIndexed || bitmap.PixelFormat == PixelFormat.Format4bppIndexed)
        {
            ColorPalette pal = bitmap.Palette;
            // no transparency info in the palette.
            if ((bitmap.Palette.Flags & 1) == 0)
                return false;
            // none of the entries in the palette have transparency information
            if (pal.Entries.All(c => c.A == 255))
                return false;
            // somewhat incomplete here: there could still be an actual check on the usage of the transparent color.
            // Would need to check specs of 4bppIndexed format to figure that out, though.
        }
        // 32-bit alpha channel types
        if (bitmap.PixelFormat == PixelFormat.Format32bppArgb || bitmap.PixelFormat == PixelFormat.Format32bppPArgb)
        {
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte[] Bytes = new byte[bitmap.Height * data.Stride];
            Marshal.Copy(data.Scan0, Bytes, 0, Bytes.Length);
            for (int p = 3; p < Bytes.Length; p += 4)
            {
                if (Bytes[p] != 255)
                    return true;
            }
            return false;
        }
        // All checks done. None of the "this isn't transparent" checks succeeded, so we assume it has transparency.
        return true;
    }
