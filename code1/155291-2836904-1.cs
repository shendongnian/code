    public Cursor GetRotatedCursor(byte[] curFileBytes, double rotationAngle)
    {
      // Load as Bitmap, convert to BitmapSource
      var origStream = new MemoryStream(curFileBytes);
      var origBitmap = new System.Drawing.Icon(origStream).ToBitmap();
      var origSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(origBitmap.GetHBitmap());
      // Construct rotated image
      var image = new Image
      {
        BitmapSource = origSource,
        RenderTransform = new RotateTransform(rotationAngle)
      };
      // Render rotated image to RenderTargetBitmap
      var width = origBitmap.Width;
      var height = origBitmap.Height;
      var resultSource = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
      resultSource.Render(image);
      // Convert to System.Drawing.Bitmap
      var pixels = new int[width*height];
      resultSource.CopyPixels(pixels, width, 0);
      var resultBitmap = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPargb);
      for(int y=0; y<height; y++)
        for(int x=0; x<width; x++)
          resultBitmap.SetPixel(x, y, Color.FromArgb(pixels[y*width+x]));
      // Save to .ico format
      var resultStream = new MemoryStream();
      new System.Drawing.Icon(resultBitmap.GetHIcon()).Save(resultStream);
      // Convert saved file into .cur format
      resultStream.Seek(2); resultStream.WriteByte(curFileBytes, 2, 1);
      resultStream.Seek(10); resultStream.WriteByte(curFileBytes, 10, 2);
      resultStream.Seek(0);
      // Construct Cursor
      return new Cursor(resultStream);
    }
