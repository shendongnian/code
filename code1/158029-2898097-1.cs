    BitmapData bmd = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, b.PixelFormat);
    byte* row = (byte*)bmd.Scan0 + (y * bmd.Stride);
    //                           Blue                    Green                   Red 
    Color c = Color.FromArgb(row[x * pixelSize + 2], row[x * pixelSize + 1], row[x * pixelSize]);
    b.UnlockBits(bmd);
