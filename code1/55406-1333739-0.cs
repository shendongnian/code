    // PixelFormatIndexed = 0x00010000, // Indexes into a palette
    // PixelFormatGDI = 0x00020000, // Is a GDI-supported format
    // PixelFormatAlpha = 0x00040000, // Has an alpha component
    // PixelFormatPAlpha = 0x00080000, // Pre-multiplied alpha
    // PixelFormatExtended = 0x00100000, // Extended color 16 bits/channel
    // PixelFormatCanonical = 0x00200000,
    // PixelFormat32bppARGB = (10 | (32 << 8) | PixelFormatAlpha | PixelFormatGDI | PixelFormatCanonical),
    
    // cheat the design time to create a bitmap with an alpha channel
    using (Bitmap bmp = new Bitmap(image.Width, image.Height, (PixelFormat) 
                                               PixelFormat32bppARGB))
    {
      // copy the original image
      using(Graphics g = Graphics.FromImage(bmp))
      {
        g.DrawImage(image,0,0);
      }
                            
      // Lock the bitmap's bits.  
      Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
      System.Drawing.Imaging.BitmapData bmpData =
      bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                (PixelFormat)PixelFormat32bppARGB);
    
      // Get the address of the first line.
      IntPtr ptr = bmpData.Scan0;
    
      // Declare an array to hold the bytes of the bitmap.
      // This code is specific to a bitmap with 32 bits per pixels.
      int bytes = bmp.Width * bmp.Height * 4;
      byte[] argbValues = new byte[bytes];
    
      // Copy the ARGB values into the array.
      System.Runtime.InteropServices.Marshal.Copy(ptr, argbValues, 0, bytes);
    
      // Set every alpha value to the given transparency.  
      for (int counter = 3; counter < argbValues.Length; counter += 4)
                               argbValues[counter] = transparency;
    
      // Copy the ARGB values back to the bitmap
      System.Runtime.InteropServices.Marshal.Copy(argbValues, 0, ptr, bytes);
    
      // Unlock the bits.
      bmp.UnlockBits(bmpData);
    
      gx.DrawImage(bmp, x, y);
    }
