    private static int InternalGetGreatestCommonDivisor(params int[] values)
    {
        // Calculate GCD for 2 or more values...
        if (values.Length > 1)
        {
          while (values.Count(value => value > 0) != 1)
          {
              int firstMaxValue = values.Max();
              int secondMaxValue = values.OrderByDescending((int @int) => @int).ElementAtOrDefault(1);
              values[values.ToList().IndexOf(firstMaxValue)] = (firstMaxValue % secondMaxValue);
          }
          return values.Max();
        }
        else
        {
          // Calculate GCD for a single value...
        }
    }
