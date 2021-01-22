    public static class DirectoryInforExtensions
    {
      public static string Combine(this DirectoryInfo directoryInfo, string fileName)
      {
        return Path.Combine(di.FullName, fileName);
      }
    }
