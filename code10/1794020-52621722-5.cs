    public static string ReadQrCode(byte[] qrCode)
    {
        BarcodeReader coreCompatReader = new BarcodeReader();
    
        using (Stream stream = new MemoryStream(qrCode))
        {
            using (var coreCompatImage = (Bitmap)Image.FromStream(stream))
            {
                return coreCompatReader.Decode(coreCompatImage).Text;
            }
        }
    }
