    public interface IHasDocumentProperties
    {
        byte[] Content { get; set; }
        string Name { get; set; }
    }
    public byte[] CreateZipFileContent(string filePath, IEnumerable<IHasDocumentProperties> fileInfos)
    {    
        using (var memoryStream = new MemoryStream())
        using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
        {
            foreach(var fileInfo in fileInfos)
            {
                var entry = zipArchive.CreateEntry(fileInfo.Name);
                using (var entryStream = entry.Open())
                {
                    entryStream.Write(fileInfo.Content, 0, fileInfo.Content.Length);
                }                        
            }
        }
           
        using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, System.IO.FileAccess.Write))
        {
            memoryStream.CopyTo(fileStream);
        }
    }
