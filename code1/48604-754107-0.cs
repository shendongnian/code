    private byte[] GetThumbNail(string imageFile) {
      try {
        Image.GetThumbnailImageAbort imageCallBack = new Image.GetThumbnailImageAbort(ThumbnailCallback);
        byte[] result;
        using (Image thumbnail = new Bitmap(160, 59)) {
          using (Bitmap source = new Bitmap(imageFile)) {
            using (Graphics g = Graphics.FromImage(thumbnail)) {
              g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
              g.InterpolationMode =  System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
              g.DrawImage(source, 0, 0, 160, 59);
            }
          }
          using (MemoryStream ms = new MemoryStream()) {
            getThumbnail.Save(ms, ImageFormat.Png);
            getThumbnail.Save("test.png", ImageFormat.Png);
            result = ms.ToArray();
          }
        }
        return result;
      } catch (Exception) {
        throw;
      }
    }
