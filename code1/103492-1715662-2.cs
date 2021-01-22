    // imgCheque source created somewhere else up here
    using (Bitmap blankImage = new Bitmap(imgCheque.Width, imgCheque.Height, PixelFormat.Format24bppRgb))
    {
        using (Graphics g = Graphics.FromImage(blankImage))
        {
            g.DrawImageUnscaledAndClipped(imgCheque, new Rectangle(Point.Empty, imgCheque.Size));
        }
        ImageCodecInfo bmpCodec = FindEncoder(ImageFormat.Bmp);
        blankImage.Save(@"C:\TEMP\output.bmp", bmpCodec, null);
    }
