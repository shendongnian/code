    public static void SaveOnNetworkShare(this System.Drawing.Image aImage, string aFilename, 
      System.Drawing.Imaging.ImageFormat aImageFormat)
    {
      using (System.IO.MemoryStream lMemoryStream = new System.IO.MemoryStream())
      {
        aImage.Save(lMemoryStream, aImageFormat);
        using (System.IO.FileStream lFileStream = new System.IO.FileStream(aFilename, System.IO.FileMode.Create))
        {
          lMemoryStream.Position = 0;
          lMemoryStream.CopyTo(lFileStream);
        }
      }      
    }
