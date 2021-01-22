    private void ConvertBitmapToWritableBitmap()
    {
        BitmapData data = colorBitmap.LockBits(colorBitmapRectangle, ImageLockMode.WriteOnly, colorBitmap.PixelFormat);
        colorWB.WritePixels(colorBitmapInt32Rect, data.Scan0, data.Width * data.Height * bytesPerPixel, data.Stride);
        colorBitmap.UnlockBits(data); 
    }
