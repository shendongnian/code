    public unsafe static int[,] GetBits(string path )
    {
       using (var orig = new Bitmap(path))
       {
          var bounds = new Rectangle(0, 0, orig.Width, orig.Height);    
          // lock the array for direct access
          var bitmapData = orig.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
    
          try
          {
             // get the pointer
             var scan0Ptr = (int*)bitmapData.Scan0;    
             // get the stride
             var stride = bitmapData.Stride / 4;    
             // keep the black around
             var black = Color.Black.ToArgb();    
             //Output
             var array = new int[orig.Width, orig.Height];
    
             // scan all x first then y
             for (var y = 0; y < bounds.Bottom; y++)
                for (var x = 0; x < bounds.Right; x++)                     
                   array[x, y] = *(scan0Ptr + x + y * stride) == black ? 0 : 1;
    
             return array;    
          }
          finally
          {
             // unlock the bitmap
             orig.UnlockBits(bitmapData);
          }    
       }
    }
