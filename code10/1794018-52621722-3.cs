    public static string ReadQrCode(byte[] qrCode)
    {
        BarcodeReader coreCompatReader = new BarcodeReader();
    
        using (Stream stream = new MemoryStream(qrCode))
        {
            using (var coreCompatImage = (Bitmap)Image.FromStream(stream))
            {
                var coreCompatResult = coreCompatReader.Decode(coreCompatImage);
                return coreCompatResult.Text;
            }
        }
    }
