    private static string GetWidthAndHeight(Image image, float dpiX, float dpiY)
    {
        float width = (float)image.Width / dpiX;
        float height = (float)image.Height / dpiY;
        int picw = (int)(width * 2540);
        int pich = (int)(height * 2540);
        int picwgoal = (int)(width * 1440);
        int pichgoal = (int)(height * 1440);
        return "\\picw" + picw + "\\pich" + pich + "\\picwgoal" + picwgoal + "\\pichgoal" + pichgoal;
    }
    public static string InsertPngImage(Image image)
    {
        byte[] buffer;
        using (var stream = new MemoryStream())
        {
            image.Save(stream, ImageFormat.Png);
            buffer = stream.ToArray();
        }
        string hex = BitConverter.ToString(buffer, 0).Replace("-", string.Empty);
        string widthAndHeight = GetWidthAndHeight(image, image.HorizontalResolution, image.VerticalResolution);
        return "{\\pict\\pngblip" + widthAndHeight + " " + hex + "}";
    }
    [Flags]
    enum EmfToWmfBitsFlags
    {
        EmfToWmfBitsFlagsDefault = 0x00000000,
        EmfToWmfBitsFlagsEmbedEmf = 0x00000001,
        EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,
        EmfToWmfBitsFlagsNoXORClip = 0x00000004
    }
    private static int MM_ANISOTROPIC = 8;
    [DllImportAttribute("gdiplus.dll")]
    private static extern uint GdipEmfToWmfBits(IntPtr hEmf, uint bufferSize, byte[] buffer, int mappingMode, EmfToWmfBitsFlags flags);
    public static string InsertWmfImage(Image image)
    {
        image = ReplaceTransparency(image, Color.White);
        Metafile metaFile;
        float dpiX;
        float dpiY;
        using (Graphics graphics = Graphics.FromImage(image))
        {
            IntPtr hdc = graphics.GetHdc();
            metaFile = new Metafile(hdc, EmfType.EmfOnly);
            graphics.ReleaseHdc(hdc);
        }
        using (Graphics graphics = Graphics.FromImage(metaFile))
        {
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
        }
        IntPtr hEmf = metaFile.GetHenhmetafile();
        uint bufferSize = GdipEmfToWmfBits(hEmf, 0, null, MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
        byte[] buffer = new byte[bufferSize];
        uint convertedSize = GdipEmfToWmfBits(hEmf, bufferSize, buffer, MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
        string hex = BitConverter.ToString(buffer, 0).Replace("-", string.Empty);
        string widthAndHeight = GetWidthAndHeight(image, dpiX, dpiY);
        return "{\\pict\\wmetafile8" + widthAndHeight + " " + hex + "}";
    }
    private static Image ReplaceTransparency(Image image, Color background)
    {
        Bitmap bitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            graphics.Clear(background);
            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
        }
        return bitmap;
    }
