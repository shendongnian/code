    private static String RemoveCharacters(string value, int count) {
      if (string.IsNullOrEmpty(value))
        return value;
      else if (count <= 1)
        return "";
      HashSet<char> toRemove = new HashSet<char>(value
        .GroupBy(c => char.ToUpper(c))
        .Where(chunk => chunk.Count() >= count)
        .Select(chunk => chunk.Key));
      return string.Concat(value.Where(c => !toRemove.Contains(char.ToUpper(c))));
    }
