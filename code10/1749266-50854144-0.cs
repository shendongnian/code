      List<string> collection = new List<string> {
        "dog",
        "cat (2)",
        "bird (34)",
        "cat + dog (11)",
        "dog (5)",
      };
      string[] order = { "dog", "bird", "cat", "cat + dog" };
      var result = collection
        .Select(item => item.Split('('))
        .Select(parts => parts.Length == 1
           ? new { name = parts[0].Trim(), count = 1 }
           : new { name = parts[0].Trim(), count = int.Parse(parts[1].Trim(')')) })
        .OrderBy(item => Array.IndexOf(order, item.name))
        .ThenBy(item => item.count)
        .Select(item => item.count == 1
           ? $"{item.name}"
           : $"{item.name} ({item.count})")
        .ToList();
     Console.WriteLine( string.Join(Environment.NewLine, result));
