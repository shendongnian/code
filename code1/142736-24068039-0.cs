    private bool AllOneColor(Bitmap bmp)
    {
        // Lock the bitmap's bits.  
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
    
        // Get the address of the first line.
        IntPtr ptr = bmpData.Scan0;
    
        // Declare an array to hold the bytes of the bitmap.
        int bytes = bmpData.Stride * bmp.Height;
        byte[] rgbValues = new byte[bytes];
    
        // Copy the RGB values into the array.
                
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
    
        bool AllOneColor = true;
        for (int index = 0; index < rgbValues.Length; index++)
        {
            //compare the current A or R or G or B with the A or R or G or B at position 0,0.
            if (rgbValues[index] != rgbValues[index % 4])
            {
                AllOneColor= false;
                break;
            }
        }
        // Unlock the bits.
        bmp.UnlockBits(bmpData);
        return AllOneColor;
    }
