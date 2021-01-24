        private void GenerateBacode(string _data, string _filename)
        {
            Linear barcode = new Linear();
            barcode.Type = BarcodeType.CODE11;
            barcode.Data = _data;
            barcode.drawBarcode(_filename);
        }
        private void GenerateQrcode(string _data, string _filename)
        {
            QRCode qrcode = new QRCode();
            qrcode.Data = _data;
            qrcode.DataMode = QRCodeDataMode.Byte;
            qrcode.UOM = UnitOfMeasure.PIXEL;
            qrcode.X = 3;
            qrcode.LeftMargin = 0;
            qrcode.RightMargin = 0;
            qrcode.TopMargin = 0;
            qrcode.BottomMargin = 0;
            qrcode.Resolution = 72;
            qrcode.Rotate = Rotate.Rotate0;
            qrcode.ImageFormat = ImageFormat.Gif;
            qrcode.drawBarcode(_filename);
        }
