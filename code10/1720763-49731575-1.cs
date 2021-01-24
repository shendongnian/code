    private static string Decode(Bitmap bitmap, bool tryMultipleBarcodes, IList<BarcodeFormat> possibleFormats)
    {
        BarcodeReader barcodeReader = new BarcodeReader();            
        var previousFormats = barcodeReader.Options.PossibleFormats;
        
        if (possibleFormats != null)
            barcodeReader.Options.PossibleFormats = possibleFormats;
        barcodeReader.Options.TryHarder = true;
        barcodeReader.TryInverted = true;
        barcodeReader.AutoRotate = true;
        
        var result = barcodeReader.Decode(bitmap);
        if (result != null) {
            return result.ToString();
        } else {
            return null;
        }
    }
