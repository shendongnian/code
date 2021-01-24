      public static IEnumerable<int> AllNotContaining<T>(this T value)
        // where T : Enum
      {
        var values = Enum.GetValues(typeof(T)).Cast<int>();
        int max = values.Max() * 2 - 1;
        for(int i = 0; i <= max; ++i)
        {
          if((max & Convert.ToInt32(value)) == 0)
          {
            yield return i;
          }
        }
      }
