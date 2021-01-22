    public class PrimeGenerator
    {
        public static IEnumerable<int> GeneratePrimes(int maxValue)
        {
            if (maxValue < 2)
                return Enumerable.Empty<int>();
            bool[] primes = new bool[maxValue + 1];
            for (int i = 2; i <= maxValue; i++)
                primes[i] = true;
            for (int i = 2; i < Math.Sqrt(maxValue + 1) + 1; i++)
            {
                if (primes[i])
                {
                    for (int j = 2 * i; j <= maxValue; j += i)
                        primes[j] = false;
                }
            }
            return primes.Select((p, i) => p ? i : 0).Where(i => i > 0);
        }
    }
