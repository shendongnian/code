    public void saveAsGif(string absPath)
    {
        int width = m_CanvasWidth;
        int height = m_CanvasHeight;
    
        GifBitmapEncoder encoder = new GifBitmapEncoder();
        BitmapPalette palette = new BitmapPalette(getPaletteAsMediaColorList(m_Pal));
    
        for (int f = 0; f < m_NumberOfFrames; f++)
        {
            FrameData frame = m_Frames[f];
            byte[] pixels = frame.pixels;
    
            BitmapSource image = BitmapSource.Create(
                width,
                height,
                96,
                96,
                System.Windows.Media.PixelFormats.Indexed8,
                palette,
                pixels,
                width);
    
            encoder.Frames.Add(BitmapFrame.Create(image));
        }
    
        byte[] GifData;
        using (MemoryStream ms = new MemoryStream())
        {
            encoder.Save(ms);
            GifData = ms.ToArray();
        }
    
        byte[] ApplicationExtention = { 33, 255, 11, 78, 69, 84, 83, 67, 65, 80, 69, 50, 46, 48, 3, 1, 0, 0, 0 };
    
        using (FileStream fs = new FileStream(absPath, FileMode.Create))
        {
            fs.Write(GifData, 0, 13);
            fs.Write(ApplicationExtention, 0, ApplicationExtention.Length);
            fs.Write(GifData, 13, GifData.Length - 13);
        }
    }
