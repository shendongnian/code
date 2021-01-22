    public bool validateImage(byte[] bytes)
    {
      try 
    {
     Stream stream = new MemoryStream(bytes);
     using(Image img = Image.FromStream(stream))
     {
       if (img.RawFormat.Equals(ImageFormat.Bmp) ||
           img.RawFormat.Equals(ImageFormat.Gif) ||
           img.RawFormat.Equals(ImageFormat.Jpeg) ||
           img.RawFormat.Equals(ImageFormat.Png))
         return true;
     }
     return false;
    } 
    catch
    {
     return false;
    }
   }
