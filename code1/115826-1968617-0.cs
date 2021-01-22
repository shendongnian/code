    int bufferSize = ((width +31) >> 5) << 2); // the width is in pixels, 1bpp,
    // so I had to round up to the nearest 32 bits
    byte[] buffer = new byte[bufferSize];
    byte[] buffer = new byte[height * bufferSize];
    for (int i = 0; i < height; i++)
    {
        getLine(buffer,bufferSize);
        Buffer.BlockCopy(bufffer,0,bigBuffer, i*bufferSize, bufferSize);
    }
    unsafe
    {
        fixed (byte* ptr = bigBuffer)
        {
            using (Bitmap image = new Bitmap(width,height,bufferSize,System.Drawing.Imaging.PixelFormat.Format1bbIndexed, new IntPtr(ptr)))
            {
                image.SetResolution(xres,yres);
                image.Save(filename,System.Drawing.Imaging.ImageFormat.Tiff);
            }
        }
    }
