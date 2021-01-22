    class Test
    {
      ArrayList matches = new ArrayList();
      void Start()
      {
        string dir = @"C:\";
        string pattern = "ABC";
        FindFiles(dir, pattern);
      }
    
      void FindFiles(string path, string pattern)
      {
        foreach(string file in Directory.GetFiles(path))
        {
          if( file.Contains(pattern) )
          {
            matches.Add(file);
          }
        }
        foreach(string directory in Directory.GetDirectories(path))
        {
          FindFiles(directory, pattern);
        }
      }
    }
