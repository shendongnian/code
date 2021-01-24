    unsafe private void ConvertImage(string fromPath, string toPath)
    {
        using (Bitmap orig = new Bitmap(fromPath))
        {
           using (Bitmap clone = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
           {
              var rect = new Rectangle(0, 0, clone.Width, clone.Height);
              using (Graphics gr = Graphics.FromImage(clone))
              {
                 gr.DrawImage(orig, rect);
              }
        
              // lock the array for direct access
              var bitmapData = clone.LockBits(Bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
              // get the pointer
              var scan0Ptr = (int*)bitmapData.Scan0;
              // get the stride
              var stride = bitmapData.Stride / 4;
        
        
              // this is if synchronous, Bounds is just the full image rectangle
        
              var white = Color.White.ToArgb();
              var black = Color.Black.ToArgb();
        
              // scan all x
              for (var x = rect.Left; x < rect.Right; x++)
              {
                 var pX = scan0Ptr + x;
        
                 // scan all y
                 for (var y = rect.Top; y < rect.Bottom; y++)
                 {
                    if (*(pX + y * stride) == black)
                    {
                       *(pX + y * stride) = white;
                    }
                    else
                    {
                       *(pX + y * stride) = black;
                    }
                 }
              }
              // unlock the bitmap
              clone.UnlockBits(bitmapData);
        
              clone.Save(toPath);
           }
        }
    }
