    System.Drawing.Image imgZenBarcode; 
    iTextSharp.text.Image imgQRCode; 
    Zen.Barcode.CodeQrBarcodeDraw qrCode = Zen.Barcode.BarcodeDrawFactory.CodeQr;           
    imgZenBarcode = qrCode.Draw( "123456", 50);
    imgQRCode = iTextSharp.text.Image.GetInstance(imgZenBarcode, System.Drawing.Imaging.ImageFormat.Png);
