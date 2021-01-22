    using (Stream fileStream = File.OpenRead(fileName))
    using (BinaryReader binaryReader = new BinaryReader(fileStream))
    using (MemoryStream memoryStream = new MemoryStream())
    {
        byte[] buffer = new byte[256];
        int count;
        int totalBytes = 0;
        while ((count = binaryReader.Read(buffer, 0, 256)) > 0)
        {
            memoryStream.Write(buffer, 0, count);
            totalBytes += count;
        }
        memoryStream.Position = 0;
        byte[] transparentPng = new byte[totalBytes];
        memoryStream.Read(transparentPng, 0, totalBytes);    
    }
