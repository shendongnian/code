     using System.Linq;
     ...
     object[][] parameters = dictionary
       .Select(pair => new object[] {pair.Key, pair.Value})
       .ToArray();
