    int WriteBitmapFile(string filename, int width, int height, byte[] imageData)
    {
      using (var stream = new MemoryStream(imageData))
      using (var bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb))
      {
        BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0,
                                                        bmp.Width,
                                                        bmp.Height),
                                          ImageLockMode.WriteOnly,
                                          bmp.PixelFormat);
    
        Marshal.Copy(imageData, 0, bmpData.Scan0, imageData.Length);
        bmp.UnlockBits(bmpData);
        
        bmp.Save(filename);
      }
    
      return 1;
    }
