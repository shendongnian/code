    public MagickImage ReadNewMagickImageFromBinary(string fileName)
    {
        var width = 1024;
        var height = 1024;
        var storageType = StorageType.Char;
        var mapping = "R";
        var pixelStorageSettings = new PixelStorageSettings(width, height, storageType, mapping);
    
        return new MagickImage(fileName, pixelStorageSettings);
    }
