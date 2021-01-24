    var pixels = bmp.Palette.Entries.Select((color, i) => new {x = color,i})
                                    .ToDictionary(arg => arg.x.ToArgb(), x => x.i);
    
    // lock the image data for direct access
    var bits = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
    
    // create array as we know the size
    var data = new byte[bmp.Height * bmp.Width];
    // pin the data array
    fixed (byte* pData = data)
    {
       // just getting a pointer we can increment
       var d = pData; 
       // store the max length so we don't have to recalculate it
       var length = (int*)bits.Scan0 + bmp.Height * bmp.Width;
    
       // Iterate through the scanlines of the image as contiguous memory by pointer 
       for (var p = (int*)bits.Scan0; p < length; p++, d++)
          //the magic, get the pixel, lookup the Dict, assign the values
          *d = (byte)pixels[*p]; 
    }
    // unlock the bitmap
    bmp.UnlockBits(bits);
