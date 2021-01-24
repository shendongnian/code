    public void GetImage(string ConvertedImageString)
    {
      string path = @"E:\\Temp\";
      if (!Directory.Exists(path)) {
        Directory.CreateDirectory(path);
      }
    
      if (!string.IsNullOrEmpty(ConvertedImageString)) {
        string converted = ConvertedImageString.Replace('-', '+');
        converted = converted.Replace('_', '/');
        using(MemoryStream ms = new MemoryStream(Convert.FromBase64String(ConvertedImageString)))
        {
          var pageFilePath = Path.Combine(path, string.Format(DateTime.Now.Ticks.ToString() + "-Image.jpg"));
          System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
          image.Save(pageFilePath, ImageFormat.Jpeg);
        }
      }
    }
