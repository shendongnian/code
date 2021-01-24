    private const string MyStorageLocation = "/0/external/Pictures"; // Or wherever
    
    private string[] GetAllPngImages()
    {
        return System.IO.Directory.GetFiles(MyStorageLocation, "*.png", System.IO.SearchOption.TopDirectoryOnly);
    }
