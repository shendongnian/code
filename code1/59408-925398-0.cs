    private MemoryStream cachedStream;
    public void CacheFile(string path)
    {
        using (var fs = new FileStream(path, FileAccess.Read))
        using (var br = new BinaryReader(fs))
        {
            cachedStream = new MemoryStream(fs.Length);
            var allData = br.ReadBytes(fs.Length);
            cachedStream.Write(allData, 0, allData.Length);
        }
    }
