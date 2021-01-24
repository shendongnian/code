      // Expected anewer: [A, B, A] 
      // since A appears two times in b only, B - just once
      string[] a = new[] { "A", "B", "A", "C", "A", "D" };
      string[] b = new[] { "A", "E", "I", "M", "A", "Q", "U", "B" };
      var quantities = b
        .GroupBy(item => item)
        .ToDictionary(chunk => chunk.Key, chunk => chunk.Count());
      string[] result = a
        .Where(item => quantities.TryGetValue(item, out var count) && 
                       ((quantities[item] = --count) >= 0))
        .ToArray();
      Console.Write(string.Join(", ", result));
