    static List<int> FindPrimesBySieveOfAtkins(int limit)
    {
        var isPrime = new BitArray((int)limit+1, false);
        var sqrt = (int)Math.Sqrt(limit);
        Parallel.For(1, sqrt, x =>
        {
            var xx = x * x;
            for (int y = 1; y <= sqrt; y++)
            {
                var yy = y * y;
                var n = 4 * xx + yy;
                if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                    isPrime[n] = !isPrime[n];
                n = 3 * xx + yy;
                if (n <= limit && n % 12 == 7)
                    isPrime[n] = !isPrime[n];
                n = 3 * xx - yy;
                if (x > y && n <= limit && n % 12 == 11)
                    isPrime[n] = !isPrime[n];
            }
        });
        var primes = new List<int>() { 2, 3 };
        for (int n = 5; n <= sqrt; n++)
        {
            if (isPrime[n])
            {
                primes.Add(n);
                int nSquared = n * n;
                for (int k = nSquared; k <= limit; k += nSquared)
                    isPrime[k] = false;
            }
        }
        for (int n = sqrt + 1; n <= limit; n++)
            if (isPrime[n])
                primes.Add(n);
        return primes;
    }
