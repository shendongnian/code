    public static Bitmap Resize(Bitmap b, int nWidth, int nHeight)
    {
        Bitmap bTemp = (Bitmap)b.Clone();
        b = new Bitmap(nWidth, nHeight, bTemp.PixelFormat);
    
        double nXFactor = (double)bTemp.Width/(double)nWidth;
        double nYFactor = (double)bTemp.Height/(double)nHeight;
    
        for (int x = 0; x < b.Width; ++x)
            for (int y = 0; y < b.Height; ++y)
                b.SetPixel(x, y, bTemp.GetPixel((int)(Math.Floor(x * nXFactor)),
                          (int)(Math.Floor(y * nYFactor))));
    
        return b;
    }
