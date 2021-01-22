    public static Bitmap ConvertTo16bpp(Image img) {
      var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
      using (var gr = Graphics.FromImage(bmp))
        gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
      return bmp;
    }
