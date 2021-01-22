    class PreconfiguredPaths {
      private readonly HashSet<string> known = new HashSet<string>();
  
      public PreconfiguredPaths(params string[] paths) {
        foreach (var p in paths)
          known.Add(Normalize(p));
      }
  
      public string Parent(string path) {
        path = Normalize(path);
  
        while (path.Length > 0) {
          if (known.Contains(path))
            return path;
          else if (!path.Contains("\\"))
            break;
  
          path = Regex.Replace(path, @"\\[^\\]+$", "");
        }
  
        return null;
      }
  
      private string Normalize(string path) {
        return Regex.Replace(path, "\\\\+", "\\").TrimEnd('\\').ToLower();
      }
    }
