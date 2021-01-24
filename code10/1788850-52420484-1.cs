      public static IEnumerable<int> AllNotContaining<T>(this T value)
        // where T : Enum  (as of C# 7.3).
      {
        // Determine upper bound of values to check.
        // E.g. for your test enum, the maximum value is 8 so we need to check up to 15.
        var values = Enum.GetValues(typeof(T)).Cast<int>();
        int max = values.Max() * 2 - 1;
        // Test all values to see if the given flag is present. If not, return it.
        for(int i = 0; i <= max; ++i)
        {
          // Possibly also: if( ((Enum)i).HasFlags(value))
          if((max & Convert.ToInt32(value)) == 0)
          {
            yield return i;
          }
        }
      }
