    byte[] data = query.ToArray();
    unsafe
    {
        fixed (byte* ptr = data)
        {
            IntPtr scan0 = new IntPtr(ptr);
            Bitmap bitmap = new Bitmap(ImageWidth, ImageHeight, // Image size
                                       ImageWidth, // Scan size
                                       PixelFormat.Format8bppIndexed, scan0);
            ColorPalette palette = bitmap.Palette;
            palette.Entries[0] = Color.Black;
            for (int i=1; i < 256; i++)
            {
                palette.Entries[i] = Color.FromArgb((i*7)%256, (i*7)%256, 255);
            }
            bitmap.Palette = palette;
            // Stuff
        }
    }
