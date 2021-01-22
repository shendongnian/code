    private Bitmap ChangePixelFormat(Bitmap inputImage, PixelFormat newFormat)
    {
      Bitmap bmp = new Bitmap(inputImage.Width, inputImage.Height, newFormat);
      using (Graphics g = Graphics.FromImage(bmp))
      {
        g.DrawImage(inputImage, 0, 0);
      }
      return bmp;
    }
