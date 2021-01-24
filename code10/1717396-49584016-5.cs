    private unsafe void ConvertImage(string fromPath, string toPath, Color source, Color target, int threshold )
    {
       using (var orig = new Bitmap(fromPath))
       {
          // create the image in a nice 32bit format
          using (var clone = new Bitmap(orig.Width, orig.Height, PixelFormat.Format32bppPArgb))
          {
             var rect = new Rectangle(0, 0, clone.Width, clone.Height);
    
             // copy the original image to that format 
             using (var gr = Graphics.FromImage(clone))
             {
                gr.DrawImage(orig, rect);
             }
    
             var thresh = threshold * threshold;
    
    
             // lock the array for direct access
             var bitmapData = clone.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
    
             // get the pointer
             var scan0Ptr = (int*)bitmapData.Scan0;
    
             // get the stride
             var stride = bitmapData.Stride / 4;
    
             // source broken up in to rgb
             var sR = source.R;
             var sG = source.G;
             var sB = source.R;
    
             // int for our target color
             var t = Color.Black.ToArgb();
    
             // scan all x
             for (var x = rect.Left; x < rect.Right; x++)
             {
                var pX = scan0Ptr + x;
    
                // scan all y
                for (var y = rect.Top; y < rect.Bottom; y++)
                {
                   // get the pixel
                   var p = pX + y * stride;
    
                   // decode the RBG from the image Pointer
                   var r = ((*p >> 0) & 255) - sR;
                   var g = ((*p >> 8) & 255) - sG;
                   var b = ((*p >> 16) & 255) - sB;
    
                   // do the threshold check, 
                   if (r * r + g * g + b * b > thresh)
                   {
                      continue;
                   }
    
                   // if we are here it means the pixel color
                   // is close to our source color
                   // so lets change it to the target color
                   *p = t;
                         
                }
             }
    
             // unlock the bitmap
             clone.UnlockBits(bitmapData);
    
             clone.Save(toPath);
          }
       }
    }
