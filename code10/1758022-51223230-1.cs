    public void GetImage(string imageString)
    {
      string imageStringToConvertIntoImage = imageString.Replace(/^data:image\/[a-z]+;base64,/, "");
      string path = @"E:\\Temp\";
      if (!Directory.Exists(path)) {
        Directory.CreateDirectory(path);
      }
    
      if (!string.IsNullOrEmpty(imageStringToConvertIntoImage)) {
        string converted = imageStringToConvertIntoImage.Replace('-', '+');
        converted = converted.Replace('_', '/');
        using(MemoryStream ms = new MemoryStream(Convert.FromBase64String(imageStringToConvertIntoImage)))
        {
          var pageFilePath = Path.Combine(path, string.Format(DateTime.Now.Ticks.ToString() + "-Image.jpg"));
          System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
          image.Save(pageFilePath, ImageFormat.Jpeg);
        }
      }
    }
