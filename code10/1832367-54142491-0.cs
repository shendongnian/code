    public static int Persistence(long n) {
      if (n < 0)
        throw new ArgumentOutOfRangeException(nameof(n));
      while (n > 9) {          // beyond a single digit
        long s = 0;
        for (; n > 0; n /= 10) // sum all the digits
          s += n % 10;
        n = s;
      }
      return (int)n;
    }
