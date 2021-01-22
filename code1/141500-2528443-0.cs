    private static bool IsLocalPath(string p)
    {
      if (p.StartsWith("http:\\"))
      {
        return false;
      }
    
      return new Uri(p).IsFile;
    }
