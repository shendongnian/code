      public static IEnumerable<string> GetNames(bool includeFirst)
      {
         var result = GetValue(includeFirst)
           .Select(v => v.ToName())
           .ToList();
         return result;
      }
