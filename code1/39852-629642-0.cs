    public static class PrimeChecker
    {
        private const int BufferSize = 64 * 1024; // 64K * sizeof(int) == 256 KB
        private static int[] primes;
        public static int MaxPrime { get; private set; }
        public static bool IsPrime(int value)
        {
            if (value <= MaxPrime)
            {
                return Array.BinarySearch(primes, value) >= 0;
            }
            else
            {
                return IsPrime(value, primes.Length) && IsLargerPrime(value);
            }
        }
        static PrimeChecker()
        {
            primes = new int[BufferSize];
            primes[0] = 2;
            for (int i = 1, x = 3; i < primes.Length; x += 2)
            {
                if (IsPrime(x, i))
                    primes[i++] = x;
            }
            MaxPrime = primes[primes.Length - 1];
        }
        private static bool IsPrime(int value, int primesLength)
        {
            for (int i = 0; i < primesLength; ++i)
            {
                if (value % primes[i] == 0)
                    return false;
            }
            return true;
        }
        private static bool IsLargerPrime(int value)
        {
            int max = (int)Math.Sqrt(value);
            for (int i = MaxPrime + 2; i <= max; i += 2)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }
    }
