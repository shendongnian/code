    public byte[] DownloadFile(string fileName)
    {
        var stream = System.IO.File.OpenRead(fileName);
        
        byte[] fileContent = new byte[stream.Length];
        stream.Read(fileContent, 0, fileContent.Length);
        return fileContent;
    }
