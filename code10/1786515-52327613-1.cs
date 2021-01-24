    var path = ...
    using(var image = Image.FromFile(path))
    using(var bitmap = new Bitmap(image))
    {
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
        var bytesPerPixel = 4; // bitmapData.PixelFormat (image.PixelFormat and bitmapData.PixelFormat can be different)
        var ptr = bitmapData.Scan0;
        var imageSize = bitmapData.Width * bitmapData.Height * bytesPerPixel;
        var data = new byte[imageSize];
        for (int x = 0; x < imageSize; x += bytesPerPixel)
        {
            for(var y = 0; y < bytesPerPixel; y++)
            {
                data[x + y] = Marshal.ReadByte(ptr);
                ptr += 1;
            }
        }
        bitmap.UnlockBits(bitmapData);
    }
