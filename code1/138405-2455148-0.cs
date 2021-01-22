    // DLL returns images as a WinForms Bitmap
    Bitmap bmp = myClass.getWinFormsBitmap();
    
    // In my situation, the images are always 640 x 480.
    BitmapData data = bmp.LockBits(new Rectangle(0, 0, 640, 480), ImageLockMode.ReadOnly,  System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    this.writeableBitmap.Lock();
    
    // Copy the bitmap's data directly to the on-screen buffers
    NativeMethods.CopyMemory(this.writeableBitmap.BackBuffer, data.Scan0, ImageBufferSize);
    
    // Moves the back buffer to the front.
    this.writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, 640, 480));
    this.writeableBitmap.Unlock();
    
    bmp.UnlockBits(data);
    
    // Free up the memory of the WinForms bitmap
    bmp.Dispose();
