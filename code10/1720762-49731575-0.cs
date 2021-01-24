    public static string Find(string fileName)
    {
        if (File.Exists(fileName)) {
            using (var bitmap = (Bitmap)Image.FromFile(fileName))
            {
               return Decode(bitmap, false, new List<BarcodeFormat> {BarcodeFormat.QR_CODE});
            }            
        }
        return null;
    }
