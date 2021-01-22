    private MemoryStream cachedStream;
    public void CacheFile(string fileName)
    {
        cachedStream = new MemoryStream(File.ReadAllBytes(fileName));
    }
