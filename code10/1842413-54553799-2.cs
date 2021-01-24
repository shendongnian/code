    int width = 300;
    int height = 400;
    Byte[] matrix = new Byte[width * height];
    Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        { 
            Color colorBefore = bmp.GetPixel(x, y);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed); 
            byte[] bytes = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            bytes[y * data.Stride + x] = 7; 
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
            bmp.UnlockBits(data); 
        }
    }
    bmp.Save("D:\\imageBimap1.jpg", ImageFormat.Jpeg);
