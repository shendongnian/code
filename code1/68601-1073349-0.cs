    void CheckDir(string path)
    {
      if(String.IsNullOrEmpty(path))
      {
        throw new ArgumentException("Path not specified.");
      }
       if(!Directory.Exists(path))
      {
        throw new DirectoryNotFoundException();
      }
    }
