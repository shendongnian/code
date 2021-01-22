    public static Bitmap BytesToBitmap(byte[] byteArray)
    {
      using (MemoryStream ms = new MemoryStream(byteArray))
      {
        Bitmap img = (Bitmap)Image.FromStream(ms);
        return img;
      }
    }
