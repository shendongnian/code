    using (var fileStream = File.OpenRead(fileName))
    {
        using (var memoryStream = new MemoryStream())
        {
            fileStream.CopyTo(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            byte[] transparentPng = memoryStream.ToArray();
        }
    }
