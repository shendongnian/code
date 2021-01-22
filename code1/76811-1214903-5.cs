    private static string GetCase(string path)
    {      
      DirectoryInfo dir = new DirectoryInfo(path);
      if (dir.Exists)
      {
        string[] folders = dir.FullName.Split(Path.DirectorySeparatorChar);
        dir = dir.Root;
        foreach (var f in folders.Skip(1))
        {          
          dir = dir.GetDirectories(f).First();
        }
        return dir.FullName;
      }
      else
      {
        return path;
      }
    }
