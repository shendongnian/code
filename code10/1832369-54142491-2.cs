    public static int Persistence(long n) {
      if (n < 0)
        throw new ArgumentOutOfRangeException(nameof(n));
      while (n > 9) {          // beyond a single digit
        long s = 1;
        for (; n > 0; n /= 10) // multiply all the digits
          s *= n % 10;
        n = s;
      }
