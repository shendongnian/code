    var data = new List<byte>();
    var pixels = bmp.Palette.Entries.Select((color,i) => new {x = color,i})
                                    .ToDictionary(arg => arg.x.ToArgb(),x=> x.i);
    // lock the array for direct access
    var bits = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
    
    // store the max length so we don't have to recalculate it
    var length = (int*)bits.Scan0 + bmp.Height * bmp.Width;
    
    // Iterate through the scanlines of the image as contiguous memory by pointer 
    for (var p = (int*)bits.Scan0; p < length; p++)           
    {
       // get the pixel, look up the dictionary, get the offset
       data.Add((byte)pixels[*p]);
    }
    
    // unlock the bitmap
    bmp.UnlockBits(bits);
