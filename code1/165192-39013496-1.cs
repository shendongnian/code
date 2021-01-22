    public static Boolean HasTransparency(Bitmap bitmap)
    {
        Int32 flags = bitmap.Flags;
        Boolean hasAplha = (flags & (Int32)ImageFlags.HasAlpha) != 0 || (flags & (Int32)ImageFlags.HasTranslucent) != 0;
        // not an alpha-capable color format.
        if (!hasAplha)
            return false;
        // Indexed formats. Special case because one index on their palette is configured as THE transparent color.
        if (bitmap.PixelFormat == PixelFormat.Format8bppIndexed || bitmap.PixelFormat == PixelFormat.Format4bppIndexed)
        {
            ColorPalette pal = bitmap.Palette;
            // no transparency info in the palette.
            if ((bitmap.Palette.Flags & 1) == 0)
                return false;
            // Find the transparent index on the palette.
            Int32 transCol = -1;
            for (int i = 0; i < pal.Entries.Length; i++)
            {
                Color col = pal.Entries[i];
                if (col.A != 255)
                {
                    // Color palettes should only have one index acting as transparency. Not sure if there's a better way of getting it...
                    transCol = i;
                    break;
                }
            }
            // none of the entries in the palette have transparency information.
            if (transCol == -1)
                return false;
            // Check pixels for existence of the transparent index.
            Int32 colDepth = Image.GetPixelFormatSize(bitmap.PixelFormat);
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            Int32 stride = data.Stride;
            Byte[] bytes = new Byte[bitmap.Height * stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            if (colDepth == 8)
            {
                // Line size. Note that this is 1-indexed.
                Int32 lineMax = bitmap.Width;
                for (Int32 i = 0; i < bytes.Length; i++)
                {
                    // Last position to processed; 1-indexed like the max we made before.
                    Int32 linepos = (i + 1) % stride;
                    // Passed last image byte of the line. Abort and go on with loop.
                    if (linepos > lineMax)
                        continue;
                    Byte b = bytes[i];
                    if (b == transCol)
                        return true;
                }
            }
            else if (colDepth == 4)
            {
                // line size in bits
                Int32 lineMax = bitmap.Width * colDepth;
                // Check if end of line ends on half a byte.
                Boolean halfByte = lineMax % 8 != 0;
                // Divide by 8, round up to nearest full byte. Note that this is 1-indexed.
                lineMax = (lineMax / 8) + (halfByte ? 1 : 0);
                for (Int32 i = 0; i < bytes.Length; i++)
                {
                    // Last position to processed; 1-indexed like the max we made before.
                    Int32 linepos = (i + 1) % stride;
                    // Passed last image byte of the line. Abort and go on with loop.
                    if (linepos > lineMax)
                        continue;
                    Byte b = bytes[i];
                    if ((b & 0x0F) == transCol)
                        return true;
                    if (halfByte && linepos == lineMax) // reached last byte of the line. If only half a byte to check on that, abort and go on with loop.
                        continue;
                    if (((b & 0xF0) >> 4) == transCol)
                        return true;
                }
            }
            return false;
        }
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
        // More methods could be added here to check the remaining alpha types like 16bppArgb1555 and 64bppArgb.
        // For now, though, none of the specific "this is not transparent" checks succeeded, so given the fact
        // alpha channel is confirmed, we assume it might have transparency in some unchecked way, 
        return true;
    }
