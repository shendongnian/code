    public void SaveImage(Graphics surface)
    {
      Bitmap bmp = new Bitmap(50, 100, surface);
      bmp.Save("filename.png", ImageFormat.Png);
    }
