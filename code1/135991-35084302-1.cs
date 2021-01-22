    static IEnumerable<string> GetSubdirectoriesContainingOnlyFiles(string path)
    {
       return Directory.GetDirectories(path, "*", SearchOption.AllDirectories)
              .Where( subdir => !Directory.GetDirectories(subdir).Any() );
    }
