    // Lock the bitmap's bits.  
    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    BitmapData bmpData =bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
    
    // Get the address of the first line.
    IntPtr ptr = bmpData.Scan0;
    
    // Declare an array to hold the bytes of the bitmap.
    int bytes  = bmpData.Stride * bmp.Height;
    byte[] rgbValues = new byte[bytes];
    
    // Copy the RGB values into the array.
    Marshal.Copy(ptr, rgbValues, 0, bytes);
    
    // Scanning for non-zero bytes
    bool allBlack = true;
    for (int index = 0; index < rgbValues.Length; index++)
        if (rgbValues[index] != 0) 
        {
           allBlack = false;
           break;
        }
    // Unlock the bits.
    bmp.UnlockBits(bmpData);
