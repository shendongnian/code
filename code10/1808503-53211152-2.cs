      int[] source = ...
      int[] result;
      int zeroCount = source.Count(item => item == 0);
      if (zeroCount >= 2) // all zeroes
        result = new int[source.Length];   
      else if (zeroCount == 1) // all zeroes except one value
        result = source
          .Select(v => v == 0
             ? source.Where(item => item != 0).Aggregate((s, a) => s * a)
             : 0)
          .ToArray(); 
      else { // no zeroes
        // long, 1L: to prevent integer overflow, e.g. for {1000000, 1000000} input
        long total = source.Aggregate(1L, (s, a) => s * a);
        result = source
          .Select(v => (int)(total / v)) // yes, it's a division...
          .ToArray(); 
      }
