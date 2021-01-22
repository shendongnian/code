    public string GetTemporaryDirectory()
    {
       string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetTempFileName);
       Directory.CreateDirectory(tempDirectory);
       return tempDirectory;
    }
