    public static Image ConvertToGrayScale(Image srce) {
      Bitmap bmp = new Bitmap(srce.Width, srce.Height);
      using (Graphics gr = Graphics.FromImage(bmp)) {
        var matrix = new float[][] {
            new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
            new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
            new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
            new float[] { 0,      0,      0,      1, 0 },
            new float[] { 0,      0,      0,      0, 1 }
        };
        var ia = new System.Drawing.Imaging.ImageAttributes();
        ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(matrix));
        var rc = new Rectangle(0, 0, srce.Width, srce.Height);
        gr.DrawImage(srce, rc, 0, 0, srce.Width, srce.Height, GraphicsUnit.Pixel, ia);
        return bmp;
      }
    }
