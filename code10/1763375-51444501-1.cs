      using System.Collections.Generic;
      ...
      private static List<double> ReadDoubles() {
        List<double> result = new List<double>();
        while (ReadDouble(out var value))
          result.Add(value);
        return result;        
      }
