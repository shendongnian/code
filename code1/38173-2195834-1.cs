             var bitmap = WpfImageHelper.ConvertToBitmap(_BarcodeCam.BitmapSource);
            _ImageEditor.Bitmap = bitmap;
            _ImageEditor.AutoDeskew();
            _ImageEditor.AdvancedBinarize();
            var reader = new BarcodeReader();
            reader.Horizontal = true;
            reader.Vertical = true;
            reader.Pdf417 = true;
            //_ImageEditor.Bitmap.Save("c:\\barcodeimage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            var barcodes = reader.Read(_ImageEditor.Bitmap);
            if (barcodes.Count() > 0)
