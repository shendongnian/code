    int bufSize = 1024 * 32;
    byte[] buffer = new byte[bufSize];
    
    using (FileStream outputFile = new FileStream(OutputFileName, FileMode.OpenOrCreate,
    FileAccess.Write, FileShare.None, bufSize))
    {
        foreach (string inputFileName in inputFiles)
        {
            using (FileStream inputFile = new FileStream(inputFileName, FileMode.Append,
                FileAccess.Write, FileShare.None, buffer.Length))
        {
        int bytesRead = 0;
    
        while ((bytesRead = inputFile.Read(buffer, 0, buffer.Length)) != 0)
        {
            outputFile.Write(buffer, 0, bytesRead);
        }
    }
