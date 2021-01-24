    public static IEnumerable<T> MergeByZipAndRemainder<T>(T[] this firsts, T[] seconds)
    {
      int maxLength = Math.Max(firsts.Length, seconds.Length);
      foreach(int i in Enumerable.Range(0, maxLength))
      {
         if (i < firsts.Length) { yield return firsts[i]; }
         if (i < seconds.Length) { yield return seconds[i]; }
      }
    }
    
