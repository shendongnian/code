    public string GetTemporaryDirectory()
    {
       string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
       Directory.CreateDirectory(tempDirectory);
       return tempDirectory;
    }
