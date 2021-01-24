    var collection = new List<string> {
        "dog",
        "cat (2)",
        "bird (34)",
        "cat + dog (11)",
        "dog (5)",
    };
    string[] order = { "dog", "bird", "cat", "cat + dog" };
    var regex = new Regex("(?<name>.*?)\\s*\\((?<number>[0-9]+)\\)");
    var result = collection
      .Select(i =>
        {
          var match = regex.Match(i);
          return new {
              content = i,
              name = match.Groups["name"].Value,
              number = int.TryParse(match.Groups["number"].Value, out int number) 
                ? number 
                : 1 };
        })
      .OrderBy(item => Array.IndexOf(order, item.name))
      .ThenBy(item => item.number)
      .Select(i => i.content)
      .ToList();
    Console.WriteLine(string.Join(Environment.NewLine, result));
    Console.ReadLine();
