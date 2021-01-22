    static IEnumerable<string> GetSubdirectoriesContainingOnlyFiles(string path)
    {
      return from subdirectory in Directory.GetDirectories(path, "*", SearchOption.AllDirectories)
             where Directory.GetDirectories(subdirectory).Length == 0
            select subdirectory;
}
