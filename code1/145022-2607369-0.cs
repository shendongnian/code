    public static string GetImagePath(string filename) {
      string exeFile = System.Reflection.Assembly.GetEntryAssembly().Location;
      string exePath = System.IO.Path.GetDirectoryName(exeFile);
      string imgPath = System.IO.Path.Combine(exePath, @"images");
      string imgFile = System.IO.Path.Combine(imgPath, filename);
      return imgFile;
    }
