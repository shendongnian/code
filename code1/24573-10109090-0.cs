    public static long IntPow(long a, long b)
    {
      long result = 1;
      for (long i = 0; i < b; i++)
        result *= a;
      return result;
    }
