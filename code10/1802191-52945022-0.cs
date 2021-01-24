    ...
    Marshal.Copy(pixels, 0, ptrFirstPixel, pixels.Length);
    processedBitmap.UnlockBits(bitmapData);
    Bitmap clone = processedBitmap.Clone(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), PixelFormat.Format1bppIndexed);
    clone.Save("G:\\aaa.bmp", ImageFormat.Bmp);
    MessageBox.Show("Success!");
