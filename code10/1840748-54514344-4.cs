    // Create file or overwrite if exists
    using (var file = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Write))
    {
        using (var writer = new StreamWriter(file, Encoding.UTF8))
        {
            writer.Write(content);
        }
    }
    
