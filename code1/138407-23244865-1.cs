    // DLL returns images as a WinForms Bitmap
    // It's disposed even if an exception is thrown
    using (Bitmap bmp = myClass.getWinFormsBitmap())
    {
        // In my situation, the images are always 640 x 480.
        BitmapData data = bmp.LockBits(new Rectangle(0, 0, 640, 480), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        writeableBitmap.WritePixels(new Int32Rect(0, 0, 640, 480), data.Scan0, ImageBufferSize, data.Stride);
        bmp.UnlockBits(data);
    }
