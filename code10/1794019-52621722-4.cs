    public static byte[] CreateQrCode(string content)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Width = 100,
                Height = 100,
            }
        };
    
        var qrCodeImage = writer.Write(content); // BOOM!!
    
        using (var stream = new MemoryStream())
        {
            qrCodeImage.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }
    }
