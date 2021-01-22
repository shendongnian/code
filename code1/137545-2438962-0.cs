    public class Primes
    {
        public static IEnumerable<int> To(int maxValue)
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
            return Enumerable.Range(2, maxValue - 1).Where(i => primes[i]);
        }
    }
