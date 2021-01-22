    private System.Drawing.Image ImageWpfToGDI(System.Windows.Media.Image image) {
      MemoryStream ms = new MemoryStream();
      var encoder = new System.Windows.Media.Imaging.BmpBitmapEncoder();
      encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(image.Source as System.Windows.Media.Imaging.BitmapSource));
      encoder.Save(ms);
      ms.Flush();      
      return System.Drawing.Image.FromStream(ms);
    }
