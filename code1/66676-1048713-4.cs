    public static List<Int32> GetPrimes(Int32 limit)
    {
        List<Int32> primes = new List<Int32>() { 2 };
        for (int n = 3; n <= limit; n += 2)
        {
            Int32 sqrt = (Int32)Math.Sqrt(n);
            if (primes.TakeWhile(p => p <= sqrt).All(p => n % p != 0))
            {
                primes.Add(n);
            }
        }
        return primes;
    }
