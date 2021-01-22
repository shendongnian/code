    string filePath = path + "\\log.log";
    string tempFilePath = path + "\\temp.log";
    string backupFilePath = path + "\\backup.log";
    using (var writer = new StreamWriter(tempFilePath, false))
    {
        // Write whatever you want to prepend
        writer.WriteLine("Hi");
    }
    using (var oldFile = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
    {
        using (var tempFile = new FileStream(tempFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
        {
            oldFile.CopyTo(tempFile);
        }
    }
    File.Replace(tempFilePath, filePath, backupFilePath);
