    Color colorBefore = bmp.GetPixel(x, y);
    BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
    // Copy the bytes from the image into a byte array
    byte[] bytes = new byte[data.Height * data.Stride];
    Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
    bytes[y * data.Stride + x] = 1; // Set the pixel at (x, y) to the color #1
    //Copy the bytes from the byte array into the image
    Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
    image.UnlockBits(data);
