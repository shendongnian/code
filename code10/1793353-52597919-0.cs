     Bitmap bmp = Bitmap.FromFile("image.png"); 
     Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
     System.Drawing.Imaging.BitmapData bmpData = 
     bmp.LockBits(rect,System.Drawing.Imaging.ImageLockMode.ReadWrite,bmp.PixelFormat;
     IntPtr ptr = bmpData.Scan0;
     int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
     byte[] rgbValues = new byte[bytes];
     System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
     for (int counter = 2; counter < rgbValues.Length; counter += 4)
     {
        int c = rgbValues[counter] > 127 ? 255: 0;
        rgbValues[counter] = c;
        rgbValues[counter+1] = c;
        rgbValues[counter+2] = c;
     }
     System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
     bmp.UnlockBits(bmpData);
