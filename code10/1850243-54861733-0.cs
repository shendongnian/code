        public static Bitmap ByteToBitmap(byte[] imageByte)
        {
        using (MemoryStream mStream = new MemoryStream())
          {
             mStream.Write(imageByte, 0, imageByte.Length); // this will stream dataand handle image length by itself
             mStream.Seek(0, SeekOrigin.Begin);
    
             Bitmap bm = new Bitmap(mStream);
             return bm;
           }
        }
