    public static int RemoveLinesFromFile(string path, string pattern)
    {
      List<string> lines = new List<string>(File.ReadAllLines(path));
      Matcher matcher = new Matcher(pattern);
      int result = lines.RemoveAll(matcher.IsMatch);
      File.WriteAllLines(path, lines.ToArray());
      return result;
    }
