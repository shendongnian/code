    Bitmap Temp = new Bitmap(inFullPathName);
    Bitmap Copy = new Bitmap(Temp.Width, Temp.Height);
    Copy.SetResolution(Temp.HorizontalResolution, Temp.VerticalResolution);
    using (Graphics g = Graphics.FromImage(Copy))
    {
         g.DrawImageUnscaled(Temp, 0, 0);
    }
    Temp.Dispose();
    return Copy;
