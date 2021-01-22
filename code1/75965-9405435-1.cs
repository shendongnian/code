    private System.Drawing.Image ImageWpfToGDI(System.Windows.Media.ImageSource image) {
      MemoryStream ms = new MemoryStream();
      var encoder = new System.Windows.Media.Imaging.BmpBitmapEncoder();
      encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(image as System.Windows.Media.Imaging.BitmapSource));
      encoder.Save(ms);
      ms.Flush();      
      return System.Drawing.Image.FromStream(ms);
    }
