    class DirectoryNormalizer
    {
      private Dictionary<string, string> directories;
    
      public DirectoryNormalizer()
      {
        directories = new Dictionary<string, string>();
      }
    
      public string Normalize(string path)
      {
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
          return path; //maybe you'd rather return string.Empty here?
        if (directories.ContainsKey(dir.FullName.ToUpper()))
          return directories[dir.FullName.ToUpper()];
        foreach (DirectoryInfo d in dir.Root.GetDirectories("*", SearchOption.AllDirectories))
        {
          if (directories.ContainsKey(d.FullName.ToUpper()))
          {
            directories[d.FullName.ToUpper()] = d.FullName;
          }
          else
          {
            directories.Add(d.FullName.ToUpper(), d.FullName);
          }
        }
        return directories[dir.FullName.ToUpper()];
      }
    }
