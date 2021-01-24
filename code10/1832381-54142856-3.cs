    public static void Persistence(long n, ref long r)
    {
       for (long s = n, i = 0; s > 9; r= ++i)
           do s *= n % 10; while ((n = n / 10) > 0);
    }
