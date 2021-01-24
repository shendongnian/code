    private unsafe static void ManipulateIndexedBitmap(Bitmap bitmap)
    {
        int bpp = Image.GetPixelFormatSize(bitmap.PixelFormat);
        BitmapData bitmapData = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadWrite, bitmap.PixelFormat);
        try
        {
            byte* line = (byte*)bitmapData.Scan0;
            // scanning through the lines
            for (int y = 0; y < bitmapData.Height; y++)
            {
                // scanning through the pixels within the line
                for (int x = 0; x < bitmapData.Width; x++)
                {
                    switch (bpp)
                    {
                        // a pixel is 1 byte - there are up to 256 palette entries 
                        case 8:
                            line[x] = (byte)TransformColor(line[x]);
                            break;
                        // a pixel is 4 bits - there are up to 16 palette entries
                        case 4:
                            // First pixel is the high nibble
                            int pos = x >> 1;
                            byte nibbles = line[pos];
                            if ((x & 1) == 0)
                            {
                                nibbles &= 0x0F;
                                nibbles |= (byte)(TransformColor(nibbles) << 4);
                            }
                            else
                            {
                                nibbles &= 0xF0;
                                nibbles |= (byte)TransformColor(nibbles >> 4);
                            }
                            line[pos] = nibbles;
                            break;
                        case 1:
                            // A pixel is 1 bit. First pixel is MSB.
                            pos = x >> 3;
                            byte mask = (byte)(128 >> (x & 7));
                            if (TransformColor(((line[pos] & mask) == 0) ? 0 : 1) == 0)
                                line[pos] &= (byte)~mask;
                            else
                                line[pos] |= mask;
                            break;
                    }
                }
                line += bitmapData.Stride;
            }
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }
    }
