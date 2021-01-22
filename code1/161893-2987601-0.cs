    public bool IsFileInUse(string path)
    {
      if (string.IsNullOrEmpty(path))
        throw new ArgumentException("'path' cannot be null or empty.", "path");
          
      try {
        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) { }
      } catch (IOException) {
        return true;
      }
      
      return false;
    }
