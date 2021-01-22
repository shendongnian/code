    public static void GetStride(int width, PixelFormat format, ref int stride, ref int bytesPerPixel)
    {
        //int bitsPerPixel = ((int)format & 0xff00) >> 8;
        int bitsPerPixel = System.Drawing.Image.GetPixelFormatSize(format);
        bytesPerPixel = (bitsPerPixel + 7) / 8;
        stride = 4 * ((width * bytesPerPixel + 3) / 4);
    }
