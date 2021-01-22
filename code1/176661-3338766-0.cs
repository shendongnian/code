      private void SetBitmap(byte[] image, int width, int height, int dpi)
      {
        MainWindow.Instance.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate()
        {
            BMemoryStream ms = new MemoryStream(image);
            JpegBitmapDecoder decoder = new JpegBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];               
            HwModeScreen.BarcodeImageCanvas.Children.Clear();
            Image myImage = new Image();
            myImage.Width = HwModeScreen.BarcodeImageCanvas.ActualWidth;
            myImage.Height = HwModeScreen.BarcodeImageCanvas.ActualHeight;
            myImage.Stretch = Stretch.Fill;
            myImage.Source = bitmapSource;
            HwModeScreen.BarcodeImageCanvas.Children.Add(myImage);
        });
