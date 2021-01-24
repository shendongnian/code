    static public string CommaSeparate(this IEnumerable<string> items) =>
      string.Join(",", items);
    static public string WithNewLines(this IEnumerable<string> items) =>
      string.Join("\n", items);
    static public IEnumerable<string> StringSort(this IEnumerable<string> items) =>
      items.OrderBy(s => s);
