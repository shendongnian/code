    public byte[] GetPixelBytes(WriteableBitmap bitmap)
    {
       int[] pixels = bitmap.Pixels;
       int length = pixels.Length * 4;
       byte[] result = new byte[length]; // ARGB
       Buffer.BlockCopy(pixels, 0, result, 0, length);
       return result;
    }
