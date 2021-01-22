    public static string ToBase64String(this Bitmap bm)
    {
      MemoryStream s = new MemoryStream();
      bm.Save(s, System.Drawing.Imaging.ImageFormat.Bmp);
      s.Position = 0;
      Byte[] bytes = new Byte[s.Length];
      s.Read(bytes, 0, (int)s.Length);
      return Convert.ToBase64String(bytes);
    }
    public static Bitmap ToBitmap(this string s)
    {
      Byte[] bytes = Convert.FromBase64String(s);
      MemoryStream stream = new MemoryStream(bytes);
      return new Bitmap(stream);
    }
