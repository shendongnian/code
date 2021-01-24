    public static long Persistence(long n)
    {
       var i = 0;
       for (var s = n; s > 9; i++)
          do s *= n % 10; while ((n = n / 10) > 0);
       return i;
    }
