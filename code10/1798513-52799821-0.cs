    using (var image = new System.Drawing.Bitmap(this.Path + "image.jpg"))
    {
       using (var croppedBitmap = image.Clone(new Rectangle((int)xCenter - width, (int)yCenter - width, width * 2, width * 2), PixelFormat.DontCare))
       {
          // not sure what you are doing here, though it doesnt make sense
          if (!File.Exists(Path + "MorphologySperms"))
          {
             // why are you creating a directory and not using it
             Directory.CreateDirectory(Path + "MorphologySperms");
          }
          // use Path.Combine
          var somePath = Path.Combine(path, "Sperms");
          croppedBitmap.Save( Path.Combine(somePath, $"sperm_{I}.jpg"));
       }
    }
