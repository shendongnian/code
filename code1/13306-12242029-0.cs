    static string StringJoin(string sep, IEnumerable<string> strings) {
      return strings
        .Skip(1)
        .Aggregate(
           new StringBuilder().Append(strings.FirstOrDefault() ?? ""), 
           (sb, x) => sb.Append(sep).Append(x));
    }
