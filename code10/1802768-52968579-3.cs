    using (var bmp = new Bitmap(fromPath))
    {   
      // lock the array for direct access int 32Bpp
      var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
      // store the max length so we don't have to recalculate it
      var length = (int*)data.Scan0 + bmp.Height * bmp.Width;
      for (var p = (int*)data.Scan0; p < length; p++)           
      {          
         //*p is your pixel as an int;
         
         // change the color like this
         *p = Color.Red.ToArgb();
         Color = Color.FromArgb(*p);
      }
      // or if you want x/y
      var p = (int*)data.Scan0;
      for (int x = 0; x < bmp.Width; x++)
         for (int y = 0; y < bmp.Height; y++)
            *(p + x + y * bmp.Width) = Color.Red.ToArgb();
      // if you want to copy the whole array 
      int[] managedArray = new int[bmp.Width * bmp.Height];
      Marshal.Copy((int*)data.Scan0, managedArray, 0, bmp.Width * bmp.Height); 
      
      // unlock the bitmap
      bmp.UnlockBits(data);
    }
