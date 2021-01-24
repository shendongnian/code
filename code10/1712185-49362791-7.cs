    // lock the array for direct access
    var bitmapData = bitmap.LockBits(Bounds, ImageLockMode.ReadWrite, Bitmap.PixelFormat);
    // get the pointer
    var  scan0Ptr = (int*)_bitmapData.Scan0;
    // get the stride
    var  stride = _bitmapData.Stride / BytesPerPixel;
    // local method
    void Workload(Rectangle bounds)
    {
       // this is if synchronous, Bounds is just the full image rectangle
       var rect = bounds ?? Bounds; 
       var white = Color.White.ToArgb();
       var black = Color.Black.ToArgb();
    
       // scan all x
       for (var x = rect.Left; x < rect.Right; x++)
       {
          var pX = scan0Ptr + x;
          // scan all y
          for (var y = rect.Top; y < rect.Bottom; y++)
          {            
             if (*(pX + y * stride ) != white)
             {
                // this will turn it to monochrome
                // so add your threshold here, ie some more for loops
                //*(pX + y * Stride) = black;
             }
          }
       }
    }
    // unlock the bitmap
    bitmap.UnlockBits(_bitmapData);
