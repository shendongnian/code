    //Create 8bpp bitmap and look bitmap data
    bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
    bmp.SetResolution(horizontalResolution, verticalResolution);
    bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
    
    //Create grayscale color table
    ColorPalette palette = bmp.Palette;
    for (int i = 0; i < 256; i++)
        palette.Entries[i] = Color.FromArgb(i, i, i);
    bmp.Palette = palette;
    
    //write data to bitmap
    int dataCount = 0;
    int stride = bmpData.Stride < 0 ? -bmpData.Stride : bmpData.Stride;
    unsafe
    {
        byte* row = (byte*)bmpData.Scan0;
        for (int f = 0; f < height; f++)
        {
            for (int w = 0; w < width; w++)
            {
                row[w] = (byte)Math.Min(255, Math.Max(0, dataB[dataCount]));
                dataCount++;
            }
            row += stride;
        }
    }
    //Unlock bitmap data
    bmp.UnlockBits(bmpData);
