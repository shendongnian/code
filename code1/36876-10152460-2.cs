    public static string GetTempFileName(string extension)
    {
      int attempt = 0;
      while (true)
      {
        string fileName = Path.GetRandomFileName();
        fileName = Path.ChangeExtension(fileName, extension);
        fileName = Path.Combine(Path.GetTempPath(), fileName);
        try
        {
          using (new FileStream(fileName, FileMode.CreateNew)) { }
          return fileName;
        }
        catch (IOException ex)
        {
          if (++attempt == 10)
            throw new IOException("No unique temporary file name is available.", ex);
        }
      }
    }
