    /// <summary>
    /// Computes the sum of the sequence of System.Double values that are obtained 
    /// by invoking one or more transform functions on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selectors">The transform functions to apply to each element.</param>    
    public static double[] SumMany<TSource>(this IEnumerable<TSource> source, params Func<TSource, double>[] selectors)
    {
      if (selectors.Length == 0)
      {
        return null;
      }
      else
      {
        double[] result = new double[selectors.Length];
    
        foreach (var item in source)
        {
          for (int i = 0; i < selectors.Length; i++)
          {
            result[i] += selectors[i](item);
          }
        }
    
        return result;
      }
    }
    
    /// <summary>
    /// Computes the sum of the sequence of System.Decimal values that are obtained 
    /// by invoking one or more transform functions on each element of the input sequence.
    /// </summary>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selectors">The transform functions to apply to each element.</param>
    public static double?[] SumMany<TSource>(this IEnumerable<TSource> source, params Func<TSource, double?>[] selectors) 
    { 
      if (selectors.Length == 0)
      {
        return null;
      }
      else
      {
        double?[] result = new double?[selectors.Length];
    
        for (int i = 0; i < selectors.Length; i++)
        {
          result[i] = 0;
        }
    
        foreach (var item in source)
        {
          for (int i = 0; i < selectors.Length; i++)
          {
            double? value = selectors[i](item);
    
            if (value != null)
            {
              result[i] += value;
            }
          }
        }
    
        return result;
      }
    }
