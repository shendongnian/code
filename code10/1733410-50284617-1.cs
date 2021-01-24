    private async void btnscan_Click(object sender, RoutedEventArgs e)
    {
        var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
        var size = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);
        CameraCaptureUI captureUI = new CameraCaptureUI();
        captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
        captureUI.PhotoSettings.CroppedSizeInPixels = new Size(size.Width, size.Height);
        StorageFile file = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
        if (file != null)
        {
            //QR code conversion from jepg and return string.
            WriteableBitmap writeableBitmap;    
            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);                
                writeableBitmap = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
                writeableBitmap.SetSource(fileStream);
                imgshow.Source = writeableBitmap;
            }
            // create a barcode reader instance
            IBarcodeReader reader = new BarcodeReader();
            // detect and decode the barcode inside the  writeableBitmap
            var barcodeReader = new BarcodeReader
            {
                AutoRotate = true,
                Options = { TryHarder = true }
            }; 
            Result result = reader.Decode(writeableBitmap);
            // do something with the result
            if (result != null)
            {
                txtDecoderType.Text = result.BarcodeFormat.ToString();
                txtDecoderContent.Text = result.Text;
            }
        }
    }
