    public string GetTemporaryDirectory()
    {
      string tempFolder = Path.GetTempFileName();
      File.Delete(tempFolder);
      Directory.CreateDirectory(tempFolder);
      
      return tempFolder;
    }
