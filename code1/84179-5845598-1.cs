    // The file we'll prepend to
    string filePath = path + "\\log.log";
    // A temp file we'll write to
    string tempFilePath = path + "\\temp.log";
    // 1) Write your prepended contents to a temp file.
    using (var writer = new StreamWriter(tempFilePath, false))
    {
        // Write whatever you want to prepend
        writer.WriteLine("Hi");
    }
    // 2) Use stream lib methods to append the original contents to the Temp
    // file.
    using (var oldFile = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
    {
        using (var tempFile = new FileStream(tempFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
        {
            oldFile.CopyTo(tempFile);
        }
    }
    // 3) Finally, dump the Temp file back to the original, keeping all its
    // original permissions etc.
    File.Replace(tempFilePath, filePath, null);
