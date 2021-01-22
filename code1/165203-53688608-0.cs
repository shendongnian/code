    public static Boolean HasTransparency(Bitmap bitmap)
    {
        BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        Int32 stride = data.Stride;
        Int32 len = bitmap.Height * stride
        Byte[] bytes = new Byte[len];
        Marshal.Copy(data.Scan0, bytes, 0, len);
        bitmap.UnlockBits(data);
        for (Int32 i = 3; i < len; i+=4)
            if (bytes[i] != 255)
                return true;
        return false;
    }
