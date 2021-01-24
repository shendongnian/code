      using System.Linq;
      ...
      var dic = text
        .Where(c => !char.IsWhiteSpace(c)))
        .GroupBy(c => c)
        .ToDictionary(chunk => chunk.Key, chunk => chunk.Count());
  
